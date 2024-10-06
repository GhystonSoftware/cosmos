import { Planet } from "@/components/Sidebar/PlanetSelect.tsx";

type PlanetStatisticsProps = {
  planet?: Planet;
};

export const PlanetStatistics = ({ planet }: PlanetStatisticsProps) => {
  return (
    <div className="my-6 border-2 border-gray-700 p-4 rounded-xl">
      {planet ? (
        <>
          <Statistic label="Name" value={planet.name} />
          <Statistic
            label="Distance from Earth"
            value={`${planet.distanceFromEarthInParsecs.toFixed(2)} parsecs`}
          />
          <Statistic
            label="Sun Temperature"
            value={`${planet.sunTemperatureInKelvin}K`}
          />
          <Statistic
            label="Relative Size to Earth"
            value={`${planet.relativeSizeToEarth.toFixed(2)} times the size of Earth`}
          />
          <Statistic
            label="Relative Mass to Earth"
            value={`${planet.relativeMassToEarth.toFixed(2)} times the mass of Earth`}
          />
          <Statistic
            label="Relative Gravity to Earth"
            value={`${planet.relativeGravityToEarth.toFixed(2)} times the gravity of Earth`}
          />
          <Statistic
            label="Number of Suns in System"
            value={`${planet.numberOfStarsInSystem}`}
          />
        </>
      ) : (
        "Select an exoplanet above 👆"
      )}
    </div>
  );
};

const Statistic = ({ label, value }: { label: string; value: string }) => {
  return (
    <p className="mb-2">
      {label}: <i>{value}</i>
    </p>
  );
};
