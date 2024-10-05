import { Header } from "./Header.tsx";
import {
  ExoplanetSelect,
  PlanetOption,
} from "@/components/Sidebar/ExoplanetSelect.tsx";
import { useState } from "react";
import { Button } from "@/components/ui/button.tsx";
import { Constellation } from "@/lib/constellation.ts";
import { PlanetStatistics } from "@/components/Sidebar/PlanetStatistics.tsx";

export type Props = {
  isCreatingConstellation: boolean;
  setIsCreatingConstellation: (isCreatingConstellation: boolean) => void;
  constellation: Constellation;
};

export const Sidebar = ({
  isCreatingConstellation,
  setIsCreatingConstellation,
  constellation,
}: Props) => {
  const [selectedPlanet, setSelectedPlanet] = useState<PlanetOption | null>(
    null,
  );

  return (
    <div className="border-2 border-gray-700 p-4 m-4 rounded-xl">
      <Header>Step 1: pick your planet</Header>
      <ExoplanetSelect value={selectedPlanet} onChange={setSelectedPlanet} />
      <PlanetStatistics planet={selectedPlanet?.planet} />
      <Header>Step 2: build your constellation!</Header>
      {!isCreatingConstellation && (
        <Button
          onClick={() => setIsCreatingConstellation(!isCreatingConstellation)}
        >
          Create Constellation
        </Button>
      )}
      {isCreatingConstellation && (
        <Button
          onClick={() => setIsCreatingConstellation(!isCreatingConstellation)}
        >
          Finish Constellation
        </Button>
      )}
      <p>Lines</p>
      <ol className="ml-2">
        {constellation.lines.map((line) => (
          <li className="list-disc" key={line.id}>
            {line.star1?.id} {"->"} {line.star2?.id}
          </li>
        ))}
      </ol>
    </div>
  );
};
