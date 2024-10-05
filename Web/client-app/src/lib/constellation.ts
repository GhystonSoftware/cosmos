import { Star } from "@/components/StarChart.tsx";

export type Constellation = {
  id: string | null;
  name: string;
  planetId?: string;
  lines: Array<ConstellationLine>;
};

export type ConstellationLine = {
  id: string;
  star1?: Star;
  star2?: Star;
};
