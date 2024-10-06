import { Header } from "@/components/Sidebar/Header.tsx";
import { Constellation } from "@/lib/constellation.ts";

export type Props = {
  constellations: Constellation[];
};

export const ExistingConstellations = ({ constellations }: Props) => {
  return (
    <>
      <Header className="mt-10">Existing Constellations</Header>
      {constellations.map((c) => (
        <p> - {c.name} </p>
      ))}
    </>
  );
};
