#!/usr/bin/python3

from enum import Enum
from typing import Callable, Union
import os

COMMENT: str = "#"
SEPARATOR: str = ","
POSTFIX: str = "_processed"

NULL: str = "NULL"

EARTH_PSEUDO_TEMP: float = 5778
PARSEC_TO_EARTH_MULTIPLIER = 3.26

INPUT = os.getenv("FILE")
if INPUT is None:
    raise ValueError("FILE env var is unset")

OUTPUT = os.getenv("OUTPUT")


def load_file(path: str) -> tuple[list[str], list[str]]:
    header = 0
    with open(path) as f:
        lines = f.readlines()
        while lines[header].startswith(COMMENT):
            header += 1
        return (lines[:header], lines[header:])


def arr_to_string(arr: list, sep: str, postfix: str = "\n") -> str:
    out = f"{arr.pop()}"
    while len(arr) > 0:
        out = f"{out}{SEPARATOR}{arr.pop()}"
    return f"{out}{postfix}"


def save_file(path: str, header: list[str], csv: list[str]) -> None:
    file = path.split(".")
    file[0] += POSTFIX
    file = ".".join(file)

    with open(file, mode="w+") as f:
        # header is dropped, because data processing changed the meaning of
        # fields and the metadata is too complex to update
        f.writelines(csv)


def write_sql(path: str, table: str, csv: list[list[str]]) -> None:
    fields = csv.pop(0)
    sql_fields = fields.pop()
    while len(fields) > 0:
        sql_fields += f",{fields.pop()}"
    sql_rows = ""
    while len(csv) > 0:
        sql_rows += f"\n({arr_to_string(csv.pop(0), ',', '')}),"
    sql_rows = sql_rows.removesuffix(",")
    sql = f"INSERT INTO {table} ({sql_fields}) VALUES {sql_rows};"

    file = path.split(".")[0] + POSTFIX + ".sql"
    with open(file, mode="w+") as f:
        # header is dropped, because data processing changed the meaning of
        # fields and the metadata is too complex to update
        f.writelines(sql)


def sanitize(csv: list[list[str]]) -> None:
    for i in range(len(csv)):
        for ii in range(len(csv[i])):
            if csv[i][ii].strip() == "":
                csv[i][ii] = None
            else:
                csv[i][ii] = csv[i][ii].strip()


def delete(
    fields: list[str], id: Union[str, list[str]], csv: list[list[str]]
) -> None:
    if isinstance(id, list):
        for id_ in id:
            delete(fields, id_, csv)
        return

    id = fields.index(id)
    del fields[id]
    for row_id in range(len(csv)):
        del csv[row_id][id]


def rename(field: list[str], new_old: dict) -> None:
    for new, old in new_old.items():
        for i in range(len(fields)):
            if fields[i] == old:
                fields[i] = new
                break


def duplicate(
    fields: list[str], csv: list[list[str]], dst_src: dict[str, str]
) -> None:
    for new_id, id in dst_src.items():
        fields.append(new_id)
        id = fields.index(id)
        for i in range(len(csv)):
            csv[i].append(csv[i][id])


def fold(
    fields: list[str],
    id: str,
    csv: list[list[str]],
    funcs: dict[str, Callable[[int, list[list[str]]], any]],
    default_func: Callable[[int, list[list[str]]], any],
) -> None:
    id = fields.index(id)
    pre_fold_coll: dict[str, list[list[str]]] = {}

    while len(csv) > 0:
        row = csv.pop()

        if row[id] not in pre_fold_coll:
            pre_fold_coll[row[id]] = [row]
        else:
            pre_fold_coll[row[id]].append(row)

    for coll_id in pre_fold_coll:
        row = []

        for field_num in range(len(fields)):
            if fields[field_num] in funcs:
                func = funcs[fields[field_num]]
            else:
                func = default_func
            row.append(func(field_num, pre_fold_coll[coll_id]))

        csv.append(row)


def filter(
    fields: list[str],
    csv: list[list[str]],
    deters: dict[str, Callable[[bool, int, list[str]], bool]],
    default_deter: Callable[[bool, int, list[str]], bool],
) -> None:
    row_id = 0
    while row_id < len(csv):
        retain = True

        for field_num in range(len(csv[row_id])):
            if fields[field_num] in deters:
                deter = deters[fields[field_num]]
            else:
                deter = default_deter

            retain = deter(retain, field_num, csv[row_id])

        if not retain:
            csv.pop(row_id)
        else:
            row_id += 1


def map(
    fields: list[str],
    csv: list[list[str]],
    funcs: list[Callable[[list[str], list[str]], None]],
) -> None:
    for i in range(len(csv)):
        for f in funcs:
            f(fields, csv[i])


def default_fold(i: int, rows: list[list[str]]) -> any:
    val = rows[0][i]

    for ii in range(len(rows)):
        assert (
            rows[ii][i] == val
        ), f"field <{i}> has none identical values. expected: {val} got: {rows[ii][i]}"

    return val


def average_fold(i: int, rows: list[list[str]]) -> any:
    nums = []

    for ii in range(len(rows)):
        if rows[ii][i] is not None:
            try:
                nums.append(float(rows[ii][i]))
            except:
                print(f"value={rows[ii][i]}")
                raise

    if len(nums) == 0:
        return NULL

    sum = 0
    for ii in range(len(nums)):
        sum += nums[ii]

    return sum / len(nums)


class Colors(Enum):
    BLUE = "blue"
    PALE_BLUE = "pale blue"
    WHITE = "white"
    PALE_YELLOW = "pale yellow"
    YELLOW = "yellow"
    ORANGE = "orange"
    RED = "red"


class Brightness(Enum):
    BRIGHT = "blindingly bright"
    MAIN = "bright"
    DIM = "dim"
    DARK = "very dim"


def spectre_type_to_color(i: int, rows: list[list[str]]) -> any:
    color_freq = {}

    for ii in range(len(rows)):
        if rows[ii][i] is not None:
            color = Colors.BLUE
            code = rows[ii][i][0]
            if code == "O":
                color = Colors.BLUE
            elif code == "B":
                color = Colors.PALE_BLUE
            elif code == "A":
                color = Colors.WHITE
            elif code == "F":
                color = Colors.PALE_YELLOW
            elif code == "G":
                color = Colors.YELLOW
            elif code == "K":
                color = Colors.ORANGE
            elif code == "M":
                color = Colors.RED

            if color in color_freq:
                color_freq[color] += 1
            else:
                color_freq[color] = 1

    if len(color_freq) == 0:
        return NULL

    mode_color = Colors.BLUE
    mode = 0
    for color in color_freq:
        if color_freq[color] > mode:
            mode = color_freq[color]
            mode_color = color

    return mode_color.value


def spectre_type_to_brightness(i: int, rows: list[list[str]]) -> any:
    brightness_freq = {}

    for ii in range(len(rows)):
        if rows[ii][i] is not None:
            brightness = Brightness.BRIGHT
            try:
                code = rows[ii][i].split(" ")[1].upper()
            except IndexError:
                code = "X"
            if code == "I" or code == "II" or code == "III":
                brightness = Brightness.BRIGHT
            elif code == "IV" or code == "V":
                brightness = Brightness.MAIN
            elif code == "VI" or code == "VII":
                brightness = Brightness.DIM
            elif code == "X":
                brightness = Brightness.DARK

            if brightness in brightness_freq:
                brightness_freq[brightness] += 1
            else:
                brightness_freq[brightness] = 1

    if len(brightness_freq) == 0:
        return NULL

    mode_bright = Brightness.BRIGHT
    mode = 0
    for b in brightness_freq:
        if brightness_freq[b] > mode:
            mode = brightness_freq[b]
            mode_bright = b

    return mode_bright


def calc_surface_gravity(fields: list, row: list) -> None:
    mass = float(row[fields.index("mass_times_earth")])
    radius = float(row[fields.index("radius_times_earth")])

    row[fields.index("surface_gravity_times_earth")] = mass / (radius**2)


def calc_surface_temp(fields: list, row: list) -> None:
    radius = float(row[fields.index("surface_temp_times_earth")])
    sun_temp = float(row[fields.index("sun_temp")])

    row[fields.index("surface_temp_times_earth")] = (
        sun_temp * ((1 / radius) ** 0.5)
    ) / EARTH_PSEUDO_TEMP


class PlantCat(Enum):
    EARTH = "proto earth"
    SUPER_EARTH = "super earth"
    JUPITER = "proto jupiter"
    SPONGE = "sponge planet"
    MOLTEN = "molten planet"
    EXO = "exo planet"


def classify_planet(fields: list, row: list) -> None:
    temp = row[fields.index("surface_temp_times_earth")]
    grav = row[fields.index("surface_gravity_times_earth")]
    mass = row[fields.index("mass_times_earth")]
    radius = row[fields.index("radius_times_earth")]

    if 0.8 < temp and temp < 1.2 and 0.8 < grav and grav < 3 and 3 < radius:
        row[fields.index("planet_type")] = PlantCat.SUPER_EARTH.value
    elif (
        0.8 < temp
        and temp < 1.2
        and 0.8 < grav
        and grav < 3
        and 0.8 < radius
        and radius < 1.2
    ):
        row[fields.index("planet_type")] = PlantCat.EARTH.value
    elif 5 < temp:
        row[fields.index("planet_type")] = PlantCat.MOLTEN.value
    elif 8 < radius and radius < 13 and 250 < mass and mass < 500:
        row[fields.index("planet_type")] = PlantCat.JUPITER.value
    elif (radius**2) / mass > 2 and temp > 1:
        row[fields.index("planet_type")] = PlantCat.SPONGE.value
    else:
        row[fields.index("planet_type")] = PlantCat.EXO.value


def adjust_brightness(fields: list, row: list) -> None:
    brightness = row[fields.index("sun_brightness")]
    if brightness is Brightness.DARK:
        brightness = 0.1
    elif brightness is Brightness.DIM:
        brightness = 1
    elif brightness is Brightness.MAIN:
        brightness = 2
    elif brightness is Brightness.BRIGHT:
        brightness = 3

    brightness *= 1 / (row[fields.index("orbital_radius")] ** 0.5)

    if brightness < 0.5:
        brightness = Brightness.DARK
    elif brightness < 1:
        brightness = Brightness.DIM
    elif brightness < 4:
        brightness = Brightness.MAIN
    else:
        brightness = Brightness.BRIGHT

    row[fields.index("sun_brightness")] = brightness.value


def gen_description(fields: list, row: list) -> None:
    accuracy = 1

    name = row[fields.index("name")]
    radius = round(row[fields.index("radius_times_earth")], accuracy)
    grav = round(row[fields.index("surface_gravity_times_earth")], accuracy)
    temp = row[fields.index("surface_temp_times_earth")]
    dist = round(
        row[fields.index("distance_pc")] * PARSEC_TO_EARTH_MULTIPLIER, accuracy
    )

    brightness = row[fields.index("sun_brightness")]
    color = row[fields.index("sun_color")]
    num = int(row[fields.index("num_of_suns")])

    row[fields.index("Description")] = (
        f"'{name}' is a {'small' if radius < 0.8 else 'large' if radius > 1.5 else 'earth sized'} exo planet that is {dist} lights years away from us. Its surface is at a {'blazing' if temp > 2 else 'freezing' if temp < 0.5 else 'comfy'} {round(temp * EARTH_PSEUDO_TEMP, accuracy)} degrees kelvin. It also boasts a {'bouncy' if grav < 0.8 else 'crushing' if grav > 2 else 'familiar'} gravitational field of {grav} times that of the earth."
    )
    row[fields.index("Description")] += (
        f" From it you'd {'barely ' if brightness == Brightness.DARK.value else ''}be able to see {'a' if num == 1 else str(num)} beautiful {'' if brightness == Brightness.DARK.value else brightness + ' '}{color} sun{'s' if num > 1 else ''}."
    )


def quote_strings(fields: list, row: list) -> None:
    for i in range(len(row)):
        try:
            assert int(row[i]) == float(row[i])
            row[i] = int(row[i])
            continue
        except (ValueError, AssertionError):
            pass

        try:
            row[i] = float(row[i])
            continue
        except ValueError:
            pass

        row[i] = f'"{row[i]}"'


# === MAIN ====================================================================

(header, csv) = load_file(INPUT)
csv = [row.split(SEPARATOR) for row in csv]
fields = csv.pop(0)
fields = [
    "row_id",
    "name",
    "num_of_suns",
    "is_controversial",
    "year_length_in_earth_days",
    "orbital_radius",
    "radius_times_earth",
    "mass_times_earth",
    "sun_type",
    "sun_temp",
    "sun_radius",
    "ra_deg",
    "dec_deg",
    "distance_pc",
]

print(f"starting rows: {len(csv)}")

delete(fields, ["row_id", "is_controversial"], csv)
duplicate(
    fields,
    csv,
    {
        "sun_brightness": "sun_type",
    },
)
sanitize(csv)

fold(
    fields,
    "name",
    csv,
    {
        "year_length_in_earth_days": average_fold,
        "orbital_radius": average_fold,
        "radius_times_earth": average_fold,
        "mass_times_earth": average_fold,
        "sun_type": spectre_type_to_color,
        "sun_temp": average_fold,
        "sun_radius": average_fold,
        "ra_deg": average_fold,
        "dec_deg": average_fold,
        "distance_pc": average_fold,
        "sun_brightness": spectre_type_to_brightness,
        # "surface_temp_times_earth": average_fold,
    },
    default_fold,
)

rename(fields, {"sun_color": "sun_type"})

filter(
    fields,
    csv,
    {
        "distance_pc": lambda r, i, row: r and (row[i] < 20),
        "name": lambda r, i, row: r
        and (
            row[i] in ["LHS 1678 b", "COCONUTS-2 b", "55 Cnc e", "HD 189733 b"]
        ),
    },
    # lambda r,_,__ : r and True
    lambda r, i, row: r and (row[i] != NULL),
)

duplicate(
    fields,
    csv,
    {
        "surface_temp_times_earth": "orbital_radius",
        "surface_gravity_times_earth": "mass_times_earth",
        "planet_type": "surface_gravity_times_earth",
        # "Description": "planet_type",
    },
)
map(
    fields,
    csv,
    [
        calc_surface_gravity,
        calc_surface_temp,
        classify_planet,
        adjust_brightness,
        # gen_description,
        quote_strings,
    ],
)
delete(
    fields,
    [
        "sun_brightness",
        # "sun_radius",
        # "sun_temp",
        # "orbital_radius",
        # "year_length_in_earth_days",
        # "planet_type",
        "orbital_radius",
        # "sun_color",
        # "surface_temp_times_earth",
        "sun_radius",
    ],
    csv,
)
csv.insert(0, fields)

rename(
    fields,
    {
        "Name": "name",
        "RightAscensionInDegrees": "ra_deg",
        "DeclinationInDegrees": "dec_deg",
        "DistanceFromEarthInParsecs": "distance_pc",
        # "RelativeBrightnessToSun": "sun_brightness",
        "SunTemperatureInKelvin": "sun_temp",
        "RelativeTemperatureToEarth": "surface_temp_times_earth",
        "RelativeSizeToEarth": "radius_times_earth",
        "RelativeMassToEarth": "mass_times_earth",
        "RelativeGravityToEarth": "surface_gravity_times_earth",
        "NumberOfStarsInSystem": "num_of_suns",
        "YearInEarthDays": "year_length_in_earth_days",
        "SunColor": "sun_color",
        "PlanetProperty": "planet_type",
    },
)

print(f"remaining rows: {len(csv)}")

if OUTPUT == "SQL":
    write_sql(INPUT, "Planets", csv)
else:
    for i in range(len(csv)):
        csv[i] = arr_to_string(csv[i], SEPARATOR)

    save_file(INPUT, header, csv)
