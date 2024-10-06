import { Header } from "./Header.tsx";
import {
  PlanetSelect,
  PlanetOption,
} from "@/components/Sidebar/PlanetSelect.tsx";
import { Constellation } from "@/lib/constellation.ts";
import { PlanetStatistics } from "@/components/Sidebar/PlanetStatistics.tsx";
import { ConstellationForm } from "@/components/Sidebar/ConstellationForm.tsx";
import { ExistingConstellations } from "@/components/Sidebar/ExistingConstellations.tsx";

export type Props = {
  isCreatingConstellation: boolean;
  setIsCreatingConstellation: (isCreatingConstellation: boolean) => void;
  newConstellation: Constellation;
  setNewConstellation: (constellation: Constellation) => void;
  selectedPlanet: PlanetOption | null;
  setSelectedPlanet: (option: PlanetOption | null) => void;
  constellations: Array<Constellation>;
  setConstellations: (constellations: Array<Constellation>) => void;
};

export const Sidebar = ({
  isCreatingConstellation,
  setIsCreatingConstellation,
  newConstellation,
  setNewConstellation,
  selectedPlanet,
  setSelectedPlanet,
  constellations,
  setConstellations,
}: Props) => {
  return (
    <div className="border-2 border-gray-700 p-4 m-4 rounded-xl w-1/4">
      <Header>Step 1: pick your planet</Header>
      <PlanetSelect value={selectedPlanet} onChange={setSelectedPlanet} />
      <PlanetStatistics planet={selectedPlanet?.planet} />
      <Header>Step 2: build your constellation!</Header>
      <ConstellationForm
        isCreatingConstellation={isCreatingConstellation}
        setIsCreatingConstellation={setIsCreatingConstellation}
        newConstellation={newConstellation}
        setNewConstellation={setNewConstellation}
        selectedPlanet={selectedPlanet?.planet}
        constellations={constellations}
        setConstellations={setConstellations}
      />
      {!!selectedPlanet?.planet.id && (
        <ExistingConstellations constellations={constellations} />
      )}
    </div>
  );
};
