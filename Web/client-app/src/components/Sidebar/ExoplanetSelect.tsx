import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "../ui/select";
import { useQuery } from "@tanstack/react-query";

export type PlanetOption = {
  label: string;
  value: string;
  planet: Planet;
};

type ExoplanetSelectProps = {
  value: PlanetOption | null;
  onChange: (option: PlanetOption | null) => void;
};

type PlanetsResponse = {
  planets: Planet[];
};

export type Planet = {
  id: number;
  name: string;
  distanceFromEarthInParsecs: number;
  relativeSunBrightness: number;
  sunTemperatureInKelvin: number;
};

export const ExoplanetSelect = (props: ExoplanetSelectProps) => {
  const { data } = useQuery({
    queryKey: ["planets"],
    queryFn: async () => {
      const response = await fetch("/api/planets");
      return ((await response.json()) as PlanetsResponse).planets.map(
        (planet) => ({
          label: planet.name,
          value: planet.name,
          planet: planet,
        }),
      );
    },
  });

  const handlePlanetChange = (value: string) => {
    const planet = data && data.find((option) => option.value === value);
    props.onChange(planet ?? null);
  };

  return (
    <div className="mb-4">
      <Select
        value={props.value?.value ?? undefined}
        onValueChange={handlePlanetChange}
      >
        <SelectTrigger className="mb-4">
          <SelectValue
            placeholder={data === undefined ? "Loading..." : "Select planet..."}
          />
        </SelectTrigger>
        <SelectContent>
          {data &&
            data.map((option) => (
              <SelectItem key={option.value} value={option.value}>
                <b>{option.label}</b>
                <span className="ml-2 text-gray-300">
                  [{option.planet.distanceFromEarthInParsecs} pc]
                </span>
              </SelectItem>
            ))}
        </SelectContent>
      </Select>
    </div>
  );
};
