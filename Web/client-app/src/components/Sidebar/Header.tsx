import React from "react";

type HeaderProps = {
  children: React.ReactNode;
};

export const Header = ({ children }: HeaderProps) => {
  return <h1 className="text-2xl font-bold mb-4">{children}</h1>;
};
