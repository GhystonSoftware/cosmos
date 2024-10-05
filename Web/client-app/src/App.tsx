import * as data from "./data/stars.json";
import { Star, StarChart } from "./components/StarChart.tsx";
import { Sidebar } from "./components/Sidebar/Sidebar.tsx";
import { Layout } from "./components/Layout.tsx";
import { useState } from "react";
import { Constellation } from "@/lib/constellation.ts";

function App() {
  const [isCreatingConstellation, setIsCreatingConstellation] = useState(false);
  const [constellation, setConstellation] = useState<Constellation>({
    id: null,
    name: "",
    lines: [],
  });

  return (
    <Layout>
      <Sidebar
        isCreatingConstellation={isCreatingConstellation}
        setIsCreatingConstellation={setIsCreatingConstellation}
        constellation={constellation}
      />
      <StarChart
        stars={data.stars as Array<Star>}
        isCreatingConstellation={isCreatingConstellation}
        constellation={constellation}
        setConstellation={setConstellation}
      />
    </Layout>
  );
}

export default App;
