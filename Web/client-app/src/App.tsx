import * as data from "./data/stars.json";
import {Star, StarChart} from "./components/StarChart.tsx";

function App(){

  return(
      <>
      <div className="bg-red-500">Test</div>
      <StarChart stars={data.stars as Array<Star>}/>
    </>
  );
}

export default App;
