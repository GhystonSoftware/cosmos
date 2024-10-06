import React from "react";
import { cn } from "@/lib/utils.ts";

type HeaderProps = {
  children: React.ReactNode;
  className?: string;
};

export const Header = ({ children, className }: HeaderProps) => {
  return (
    <h1 className={cn(className, "text-2xl font-bold mb-6")}>{children}</h1>
  );
};
