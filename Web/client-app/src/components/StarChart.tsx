import * as d3 from "d3";
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
  const chartCanvasRef = useD3((drawingCanvas, chartAreaWidth) => {
    drawingCanvas.select("svg").remove();

    console.log(stars);

    const width = chartAreaWidth;
    const height = width;

    const cx = width / 2;
    const cy = height / 2;
    const radius = d3.scaleLinear([6, -1], [0, 8]);
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

    // const voronoi = d3.Delaunay
    //   .from(data.map(projection))
    //   .voronoi([0, 0, width, height]);

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
  });

  return <div style={{ width: "50vw", height: "100%" }} ref={chartCanvasRef} />;
};
