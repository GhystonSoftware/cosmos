import { Button } from "@/components/ui/button.tsx";
import { Constellation } from "@/lib/constellation.ts";
import { LucideTrash, Save } from "lucide-react";
import { Lines } from "@/components/Sidebar/Lines.tsx";
import { Input } from "@/components/ui/input.tsx";
import { useState } from "react";
import { Planet } from "@/components/Sidebar/PlanetSelect.tsx";

export interface ErrorResponse {
  message: string;
}

export type Props = {
  isCreatingConstellation: boolean;
  setIsCreatingConstellation: (value: boolean) => void;
  newConstellation: Constellation;
  setNewConstellation: (value: Constellation) => void;
  selectedPlanet?: Planet;
  constellations: Array<Constellation>;
  setConstellations: (value: Array<Constellation>) => void;
};

export const ConstellationForm = ({
  isCreatingConstellation,
  setIsCreatingConstellation,
  newConstellation,
  setNewConstellation,
  selectedPlanet,
  constellations,
  setConstellations,
}: Props) => {
  const [constellationName, setConstellationName] = useState<string>("");

  return (
    <>
      {!isCreatingConstellation && (
        <Button
          disabled={!selectedPlanet}
          onClick={() => setIsCreatingConstellation(!isCreatingConstellation)}
        >
          Create Constellation
        </Button>
      )}

      {isCreatingConstellation && (
        <>
          <Lines
            isCreatingConstellation={isCreatingConstellation}
            constellation={newConstellation}
          />

          <div className="flex justify-between items-center space-x-3">
            <label>Name</label>
            <Input
              value={constellationName}
              onChange={(e) => setConstellationName(e.target.value)}
            />
          </div>
          <div className="flex justify-between my-2">
            <Button
              onClick={() => {
                setConstellations([
                  ...constellations,
                  { ...newConstellation, name: constellationName },
                ]);
                setIsCreatingConstellation(false);
                setConstellationName("");
              }}
            >
              Save Constellation
              <Save className="ml-2" />
            </Button>
            <Button
              onClick={() => {
                setNewConstellation({ ...newConstellation, lines: [] });
                setIsCreatingConstellation(false);
              }}
            >
              Cancel <LucideTrash className="ml-2" />{" "}
            </Button>
          </div>
        </>
      )}
    </>
  );
};
