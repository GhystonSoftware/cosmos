﻿import * as d3 from "d3";
import { useD3 } from "../hooks/useD3.ts";

export type Star = {
  x: number;
  y: number;
  brightness: number; // apparentBrightness or alpha??
};

export type Props = {
  stars: Array<Star>;
};

export const StarChart = ({ stars }: Props) => {
  const chartCanvasRef = useD3((drawingCanvas, chartAreaWidth, chartAreaHeight) => {
    drawingCanvas.select("svg").remove();

    const width = chartAreaWidth;
    const height = chartAreaHeight;

    const radius = d3.scaleLinear([6, -1], [0, 8]);
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

    svg
      .append("path")
      .attr("d", path(graticule))
      .attr("fill", "none")
      .attr("stroke", "currentColor")
      .attr("stroke-opacity", 0.2);

    svg.append("g")
      .attr("stroke", "black")
      .selectAll()
      .data(stars)
      .join("circle")
      .attr("r", star => radius(star.brightness))
      .attr("transform", star => `translate(${projection([star.x, star.y])})`);
  });

  return <div style={{ width: "100vh", height: "100vh" }} ref={chartCanvasRef} />;
};
