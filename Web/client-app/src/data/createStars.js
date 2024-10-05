import { writeFileSync } from "fs";
import _ from "lodash";

const stars = [];

for (let i = 0; i < 100; i++) {
  stars.push({
    id: _.uniqueId(),
    x: (0.5 - Math.random()) * 1000,
    y: (0.5 - Math.random()) * 1000,
    brightness: 0.6 + Math.random() * 0.4,
  });
}

writeFileSync("./stars.json", JSON.stringify(stars));
