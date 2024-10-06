import { Constellation, ConstellationLine } from "@/lib/constellation.ts";
import { Star } from "@/components/StarChart.tsx";
import _ from "lodash";

export const createNewBlankConstellation = (): Constellation => ({
  id: _.uniqueId(),
  name: "",
  lines: [],
});

export const updateConstellationOnStarClick = (
  constellation: Constellation,
  star: Star,
): Constellation => {
  const lastLine = constellation.lines.at(-1);

  if (!lastLine) {
    const newLine: ConstellationLine = {
      id: _.uniqueId(),
      star1: star,
      star2: undefined,
    };

    return {
      ...constellation,
      lines: [...constellation.lines, newLine],
    };
  }

  if (!!lastLine.star1 && !lastLine.star2) {
    if (lastLine.star1.id === star.id) {
      return constellation;
    }
    const newLine: ConstellationLine = {
      ...lastLine,
      star2: star,
    };

    return {
      ...constellation,
      lines: [...constellation.lines.slice(0, -1), newLine],
    };
  }

  if (!!lastLine.star1 && !!lastLine.star2) {
    const newLine: ConstellationLine = {
      id: _.uniqueId(),
      star1: star,
      star2: undefined,
    };

    return {
      ...constellation,
      lines: [...constellation.lines, newLine],
    };
  }

  return constellation;
};

export const hasConstellationSelectedFirstStar = (
  constellation: Constellation,
): boolean => {
  const lastLine = constellation.lines.at(-1);

  return !!lastLine && !!lastLine.star1 && !lastLine.star2;
};
