import * as d3 from "d3";
import { useD3 } from "../hooks/useD3.ts";
import "../assets/styles/StarChart.css";
import {
  addCircleClipPath,
  addConstellationLines,
  addGraticule,
  addOutline,
  addRadialGradient,
  addStars,
  addTicks,
} from "@/helpers/starChartHelpers.ts";
import { Constellation } from "@/lib/constellation.ts";
import {
  hasConstellationSelectedFirstStar,
  updateConstellationOnStarClick,
} from "@/helpers/constellationHelpers.ts";
import { PlanetOption } from "@/components/Sidebar/PlanetSelect.tsx";
import { useQuery } from "@tanstack/react-query";

export type Props = {
  selectedPlanet: PlanetOption | null;
  isCreatingConstellation: boolean;
  constellation: Constellation;
  setConstellation: (constellation: Constellation) => void;
};

type StarResponse = {
  stars: Star[];
};

export type Star = {
  id: string;
  x: number;
  y: number;
  brightness: number; // apparentBrightness or alpha??
};

//TODO; Add some UI indicator background or text that says creating constellation ?
export const StarChart = ({
  selectedPlanet,
  isCreatingConstellation,
  constellation,
  setConstellation,
}: Props) => {
  const { data } = useQuery({
    queryKey: ["stars", selectedPlanet?.planet.id],
    queryFn: async () => {
      if (selectedPlanet === null) {
        return null;
      }

      const response = await fetch(`/api/stars/${selectedPlanet.planet.id}`);

      return (await response.json()) as StarResponse;
    },
  });

  const onStarClick = (_: MouseEvent, star: Star) => {
    if (!isCreatingConstellation) return;

    setConstellation(updateConstellationOnStarClick(constellation, star));
  };

  const chartCanvasRef = useD3(
    (drawingCanvas, chartAreaWidth, chartAreaHeight) => {
      drawingCanvas.select("svg").remove();

      const width = chartAreaWidth;
      const height = chartAreaHeight;

      const radius = d3.scaleLinear([0.6, 1], [2, 6]);
      const outline = d3.geoCircle().radius(90).center([0, 90])();
      const graticule = d3.geoGraticule().stepMinor([15, 10])();

      const projection = d3
        .geoStereographic()
        .reflectY(true)
        .scale((width - 120) * 0.5)
        .clipExtent([
          [0, 0],
          [width, height],
        ])
        .rotate([0, -90])
        .translate([width / 2, height / 2])
        .precision(0.1);

      const path = d3.geoPath(projection);

      const hasSelectedFirstStar =
        hasConstellationSelectedFirstStar(constellation);

      const svg = drawingCanvas
        .append("svg")
        .attr("width", width)
        .attr("height", height)
        .attr("viewBox", [0, 0, width, height])
        .attr(
          "style",
          "display: block; margin: 0 -14px; width: 100%; height: auto; font: 10px sans-serif; color: white;",
        )
        .attr("text-anchor", "middle")
        .attr("fill", "currentColor")
        .attr("class", hasSelectedFirstStar ? "cursor-crosshair" : "");

      const defs = svg.append("defs");

      addCircleClipPath(defs, svg, width, height);

      addRadialGradient(defs, "fadeGradient");

      addOutline(svg, path, outline);

      addGraticule(svg, path, graticule);

      addTicks(svg, projection);

      addConstellationLines(svg, projection, constellation);

      if (data) {
        addStars(
          svg,
          projection,
          data.stars,
          radius,
          onStarClick,
          isCreatingConstellation,
        );
      }
    },
  );

  return (
    <div
      style={{
        width: "100vw",
        height: "100vh",
        maxWidth: "100vh",
        maxHeight: "100vw",
      }}
      ref={chartCanvasRef}
    />
  );
};
