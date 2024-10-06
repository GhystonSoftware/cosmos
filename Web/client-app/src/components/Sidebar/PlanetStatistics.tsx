import { Planet } from "@/components/Sidebar/PlanetSelect.tsx";
import { cn } from "@/lib/utils.ts";

type PlanetStatisticsProps = {
  planet?: Planet;
};

export const PlanetStatistics = ({ planet }: PlanetStatisticsProps) => {
  return (
    <div className="mt-6 mb-12 border-2 border-gray-700 rounded-xl">
      {planet ? (
        <table className="w-full">
          <Statistic label="Name" value={planet.name} first />
          <Statistic label="Planet Property" value={planet.planetProperty} />
          <Statistic
            label="Distance from Earth"
            value={`${planet.distanceFromEarthInParsecs.toFixed(2)} parsecs`}
          />
          <Statistic
            label="Sun Temperature"
            value={`${planet.sunTemperatureInKelvin}K`}
          />
          <Statistic
            label="Relative Temperature to Earth"
            value={`${planet.relativeSizeToEarth.toFixed(2)} times`}
          />
          <Statistic
            label="Relative Size to Earth"
            value={`${planet.relativeSizeToEarth.toFixed(2)} times`}
          />
          <Statistic
            label="Relative Mass to Earth"
            value={`${planet.relativeMassToEarth.toFixed(2)} times`}
          />
          <Statistic
            label="Relative Gravity to Earth"
            value={`${planet.relativeGravityToEarth.toFixed(2)} times`}
          />
          <Statistic
            label="Relative Gravity to Earth"
            value={`${planet.yearInEarthDays} times`}
          />
          <Statistic label="Sun Color" value={planet.sunColor} />
          <Statistic
            label="Number of Suns in System"
            value={`${planet.numberOfStarsInSystem}`}
          />
        </table>
      ) : (
        <div className="p-4">Select an exoplanet above 👆</div>
      )}
    </div>
  );
};

const Statistic = ({
  label,
  value,
  first,
}: {
  label: string;
  value: string;
  first?: boolean;
}) => {
  return (
    <tr className="mb-2 border-b-2 border-gray-700 last:border-none">
      <td
        className={cn(
          "p-2 border-gray-500 font-bold",
          first && "bg-gray-800 rounded-tl-xl",
        )}
      >
        {label}
      </td>
      <td
        className={cn(
          "p-2 border-gray-500",
          first && "bg-gray-800 rounded-tr-xl",
        )}
      >
        {value}
      </td>
    </tr>
  );
};
