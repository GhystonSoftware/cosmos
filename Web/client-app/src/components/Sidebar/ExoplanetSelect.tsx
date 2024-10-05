import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "../ui/select";

export type PlanetOption = {
  label: string;
  value: string;
  gravity: number;
};

type ExoplanetSelectProps = {
  options: PlanetOption[];
  value: PlanetOption | null;
  onChange: (option: PlanetOption | null) => void;
};

export const ExoplanetSelect = (props: ExoplanetSelectProps) => {
  const handlePlanetChange = (value: string) => {
    const planet = props.options.find((option) => option.value === value);
    props.onChange(planet ?? null);
  };

  return (
    <div>
      <Select
        value={props.value?.value ?? undefined}
        onValueChange={handlePlanetChange}
      >
        <SelectTrigger className="mb-4">
          <SelectValue placeholder="Planet..." />
        </SelectTrigger>
        <SelectContent>
          {props.options.map((option) => (
            <SelectItem key={option.value} value={option.value}>
              {option.label}
            </SelectItem>
          ))}
        </SelectContent>
      </Select>
    </div>
  );
};

// TODO: pull this from the API
export const defaultPlanetOptions: PlanetOption[] = [
  { label: "51 Pegasi b", value: "51 Pegasi b", gravity: 0.47 },
  { label: "55 Cancri e", value: "55 Cancri e", gravity: 1.55 },
  { label: "Gliese 581 c", value: "Gliese 581 c", gravity: 2.5 },
];
