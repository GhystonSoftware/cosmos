import { StarChart } from "./components/StarChart.tsx";
import { Sidebar } from "./components/Sidebar/Sidebar.tsx";
import { Layout } from "./components/Layout.tsx";
import { useState } from "react";
import { Constellation } from "@/lib/constellation.ts";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { PlanetOption } from "@/components/Sidebar/PlanetSelect.tsx";
import { createNewBlankConstellation } from "@/helpers/constellationHelpers.ts";

function App() {
  const queryClient = new QueryClient();
  const [isCreatingConstellation, setIsCreatingConstellation] = useState(false);
  const [newConstellation, setNewConstellation] = useState<Constellation>(
    createNewBlankConstellation(),
  );
  const [selectedPlanet, setSelectedPlanet] = useState<PlanetOption | null>(
    null,
  );
  const [constellations, setConstellations] = useState<Constellation[]>([]);

  const handlePlanetChange = (value: PlanetOption | null) => {
    setNewConstellation(createNewBlankConstellation());
    setSelectedPlanet(value);
  };

  return (
    <QueryClientProvider client={queryClient}>
      <Layout>
        <Sidebar
          isCreatingConstellation={isCreatingConstellation}
          setIsCreatingConstellation={setIsCreatingConstellation}
          newConstellation={newConstellation}
          setNewConstellation={setNewConstellation}
          selectedPlanet={selectedPlanet}
          setSelectedPlanet={handlePlanetChange}
          constellations={constellations}
          setConstellations={setConstellations}
        />
        <StarChart
          selectedPlanet={selectedPlanet}
          isCreatingConstellation={isCreatingConstellation}
          newConstellation={newConstellation}
          setNewConstellation={setNewConstellation}
          constellations={constellations}
          setConstellations={setConstellations}
        />
      </Layout>
    </QueryClientProvider>
  );
}

export default App;
