import * as d3 from "d3";

export const addCircleClipPath = (
  defs: d3.Selection<SVGDefsElement, unknown, null, undefined>,
  svg: d3.Selection<SVGSVGElement, unknown, null, undefined>,
  width: number,
  height: number,
) => {
  defs
    .append("clipPath")
    .attr("id", "circle-clip")
    .append("circle")
    .attr("cx", width / 2)
    .attr("cy", height / 2)
    .attr("r", width / 2);

  svg.attr("clip-path", "url(#circle-clip)");
};

export const addRadialGradient = (
  defs: d3.Selection<SVGDefsElement, unknown, null, undefined>,
  id: string,
) => {
  const radialGradient = defs
    .append("radialGradient")
    .attr("id", id)
    .attr("cx", "50%")
    .attr("cy", "50%")
    .attr("r", "60%")
    .attr("fx", "50%")
    .attr("fy", "50%");

  radialGradient
    .append("stop")
    .attr("offset", "0%")
    .attr("stop-color", "white")
    .attr("stop-opacity", 1);

  radialGradient
    .append("stop")
    .attr("offset", "100%")
    .attr("stop-color", "white")
    .attr("stop-opacity", 0.25);
};

export const addGraticule = (
  svg: d3.Selection<SVGSVGElement, unknown, null, undefined>,
  path: d3.GeoPath<any, d3.GeoPermissibleObjects>,
  graticule: any,
) => {
  svg
    .append("path")
    .attr("d", path(graticule))
    .attr("fill", "none")
    .attr("stroke", "currentColor")
    .attr("stroke-opacity", 0.2);
};

export const addOutline = (
  svg: d3.Selection<SVGSVGElement, unknown, null, undefined>,
  path: d3.GeoPath<any, d3.GeoPermissibleObjects>,
  outline: any,
) => {
  svg
    .append("path")
    .attr("d", path(outline))
    .attr("fill", "none")
    .attr("stroke", "currentColor");
};

// Function to draw ticks
export const addTicks = (
  svg: d3.Selection<SVGSVGElement, unknown, null, undefined>,
  projection: d3.GeoProjection,
) => {
  // 5-minute ticks
  svg
    .append("g")
    .attr("stroke", "currentColor")
    .selectAll()
    .data(d3.range(0, 1440, 5)) // every 5 minutes
    .join("line")
    .datum((d) => [
      projection([d / 4, 0]),
      projection([d / 4, d % 60 ? -1 : -2]),
    ])
    .attr("x1", (d) => (d ? (d[0] ? [0] : 0) : 0))
    .attr("x2", (d) => (d ? (d[1] ? [0] : 0) : 0))
    .attr("y1", (d) => (d ? (d[0] ? [1] : 0) : 0))
    .attr("y2", (d) => (d ? (d[1] ? [1] : 0) : 0));

  // Hourly ticks and labels
  svg
    .append("g")
    .selectAll()
    .data(d3.range(0, 1440, 60)) // every hour
    .join("text")
    .attr("dy", "0.35em")
    .text((d) => `${d / 60}h`)
    .attr("font-size", (d) => (d % 360 ? null : 14))
    .attr("font-weight", (d) => (d % 360 ? null : "bold"))
    .datum((d) => projection([d / 4, -4]))
    .attr("x", (d) => (d ? d[0] : 0))
    .attr("y", (d) => (d ? d[1] : 0));

  // 10° labels
  svg
    .append("g")
    .selectAll()
    .data(d3.range(10, 91, 10))
    .join("text")
    .attr("dy", "0.35em")
    .text((d) => `${d}°`)
    .datum((d) => projection([0, d]))
    .attr("x", (d) => (d ? d[0] : 0))
    .attr("y", (d) => (d ? d[1] : 0));
};

export const addStars = (
  svg: d3.Selection<SVGSVGElement, unknown, null, undefined>,
  projection: d3.GeoProjection,
  stars: any[],
  radius: (brightness: number) => number,
) => {
  svg
    .append("g")
    .attr("stroke", "transparent")
    .selectAll()
    .data(stars)
    .join("circle")
    .attr("r", (star) => radius(star.brightness))
    .attr("class", "star")
    .attr("fill", "url(#fadeGradient)")
    .attr("transform", (star) => `translate(${projection([star.x, star.y])})`);
};
