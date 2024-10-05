import { PlanetOption } from "@/components/Sidebar/ExoplanetSelect.tsx";

type PlanetStatisticsProps = {
  planet: PlanetOption | null;
};

export const PlanetStatistics = ({ planet }: PlanetStatisticsProps) => {
  return (
    <div>
      Selected planet:
      <div className="border-2 border-gray-700 p-4 m-4 rounded-xl">
        {planet ? (
          <>
            <Statistic label="Name" value={planet.label} />
            <Statistic
              label="Gravity"
              value={`${planet.gravity * 9.81} m/s²`}
            />
          </>
        ) : (
          "None"
        )}
      </div>
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
