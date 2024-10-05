import * as d3 from "d3";
import { useD3 } from "../hooks/useD3.ts";
import "../assets/styles/StarChart.css";
import {
  addCircleClipPath,
  addGraticule,
  addRadialGradient,
  addStars,
  addTicks,
} from "@/helpers/starChartHelpers.ts";

export type Star = {
  x: number;
  y: number;
  brightness: number; // apparentBrightness or alpha??
};

export type Props = {
  stars: Array<Star>;
};

export const StarChart = ({ stars }: Props) => {
  const chartCanvasRef = useD3(
    (drawingCanvas, chartAreaWidth, chartAreaHeight) => {
      drawingCanvas.select("svg").remove();

      const width = chartAreaWidth;
      const height = chartAreaHeight;

      const radius = d3.scaleLinear([0.6, 1], [2, 6]);
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
        .attr("fill", "currentColor");

      const defs = svg.append("defs");

      addCircleClipPath(defs, svg, width, height);

      addRadialGradient(defs, "fadeGradient");

      addGraticule(svg, path, graticule);

      addTicks(svg, projection);

      addStars(svg, projection, stars, radius);
      //stars
      svg
        .append("g")
        .attr("stroke", "transparent")
        .selectAll()
        .data(stars)
        .join("circle")
        .attr("r", (star) => radius(star.brightness))
        .attr("class", "star")
        .attr("fill", "url(#fadeGradient)")
        .attr(
          "transform",
          (star) => `translate(${projection([star.x, star.y])})`,
        );
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
