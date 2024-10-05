import { Planet } from "@/components/Sidebar/ExoplanetSelect.tsx";

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
            label="Relative Sun Brightness"
            value={`${planet.relativeSunBrightness.toFixed(2)} times the brightness of the Sun`}
          />
          <Statistic
            label="Sun Temperature"
            value={`${planet.sunTemperatureInKelvin}K`}
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
