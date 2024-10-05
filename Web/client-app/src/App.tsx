import * as data from "./data/stars.json";
import { Star, StarChart } from "./components/StarChart.tsx";
import { Sidebar } from "./components/Sidebar.tsx";
import { Layout } from "./components/Layout.tsx";

function App() {
  return (
    <Layout>
      <Sidebar />
      <StarChart stars={data.stars as Array<Star>} />
    </Layout>
  );
}

export default App;
