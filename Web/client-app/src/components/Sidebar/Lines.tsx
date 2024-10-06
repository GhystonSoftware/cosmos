import { Constellation } from "../../lib/constellation";

export type Props = {
  isCreatingConstellation: boolean;
  constellation: Constellation;
};

export const Lines = ({ isCreatingConstellation, constellation }: Props) => {
  return (
    <>
      <p className="mt-2">Lines</p>
      <ol className=" ml-2 my-2">
        {constellation.lines.map((line) => (
          <li className="list-disc" key={line.id}>
            {line.star1?.id} {"->"} {line.star2?.id}
          </li>
        ))}
        {isCreatingConstellation && constellation.lines.length === 0 && (
          <li className="list-disc my-2">No lines yet</li>
        )}
      </ol>
    </>
  );
};
