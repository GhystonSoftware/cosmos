import { writeFileSync } from "fs";
import _ from "lodash";

const Stars = [];

for (let i = 0; i < 100; i++) {
  Stars.push({
    Id: _.uniqueId(),
    X: (0.5 - Math.random()) * 1000,
    Y: (0.5 - Math.random()) * 1000,
    Brightness: 0.6 + Math.random() * 0.4,
  });
}

writeFileSync("./stars.json", JSON.stringify(Stars));
