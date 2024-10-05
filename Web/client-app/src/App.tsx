import { StarChart } from "./components/StarChart.tsx";
import { Sidebar } from "./components/Sidebar/Sidebar.tsx";
import { Layout } from "./components/Layout.tsx";
import { useState } from "react";
import { Constellation } from "@/lib/constellation.ts";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { PlanetOption } from "@/components/Sidebar/ExoplanetSelect.tsx";

const initialConstellation: Constellation = {
  id: null,
  name: "",
  lines: [],
};

function App() {
  const queryClient = new QueryClient();
  const [isCreatingConstellation, setIsCreatingConstellation] = useState(false);
  const [constellation, setConstellation] =
    useState<Constellation>(initialConstellation);
  const [selectedPlanet, setSelectedPlanet] = useState<PlanetOption | null>(
    null,
  );

  const handlePlanetChange = (value: PlanetOption | null) => {
    setConstellation(initialConstellation);
    setSelectedPlanet(value);
  };

  return (
    <QueryClientProvider client={queryClient}>
      <Layout>
        <Sidebar
          isCreatingConstellation={isCreatingConstellation}
          setIsCreatingConstellation={setIsCreatingConstellation}
          constellation={constellation}
          selectedPlanet={selectedPlanet}
          setSelectedPlanet={handlePlanetChange}
        />
        <StarChart
          selectedPlanet={selectedPlanet}
          isCreatingConstellation={isCreatingConstellation}
          constellation={constellation}
          setConstellation={setConstellation}
        />
      </Layout>
    </QueryClientProvider>
  );
}

export default App;
