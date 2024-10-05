import { Header } from "./Header.tsx";
import {
  defaultPlanetOptions,
  ExoplanetSelect,
  PlanetOption,
} from "@/components/Sidebar/ExoplanetSelect.tsx";
import { useState } from "react";
import { PlanetStatistics } from "@/components/Sidebar/PlanetStatistics.tsx";

export const Sidebar = () => {
  const [selectedPlanet, setSelectedPlanet] = useState<PlanetOption | null>(
    null,
  );

  return (
    <div className="border-2 border-gray-700 p-4 m-4 rounded-xl">
      <Header>Step 1: pick your planet</Header>
      <ExoplanetSelect
        options={defaultPlanetOptions}
        value={selectedPlanet}
        onChange={setSelectedPlanet}
      />
      <PlanetStatistics planet={selectedPlanet} />
      <Header>Step 2: build your constellation!</Header>
      TODO - add the list of stars you selected here
    </div>
  );
};
