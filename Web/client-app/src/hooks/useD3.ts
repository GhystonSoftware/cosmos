import { useEffect, useRef, useState } from "react";
import type { Selection } from "d3";
import { select } from "d3";

export const useD3 = (
  renderChart: (
    ref: Selection<HTMLDivElement, unknown, null, undefined>,
    chartAreaWidth: number,
    chartAreaHeight: number
  ) => void
) => {
  const ref = useRef<HTMLDivElement>(null);
  const [width, setWidth] = useState<number>();
  const [height, setHeight] = useState<number>();

  const getContainerSize = () => {
    const newWidth = ref.current?.clientWidth;
    setWidth(newWidth);

    const newHeight = ref.current?.clientHeight;
    setHeight(newHeight);
  };

  useEffect(() => {
    getContainerSize();
    window.addEventListener("resize", getContainerSize);
    return () => window.removeEventListener("resize", getContainerSize);
  }, []);

  useEffect(() => {
    if (ref.current) {
      renderChart(select(ref.current), ref.current.clientWidth, ref.current.clientHeight);
    }
  }, [ref, renderChart, width, height]);

  return ref;
};
