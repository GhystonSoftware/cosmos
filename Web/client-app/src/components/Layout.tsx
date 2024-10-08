import React from "react";

type LayoutProps = {
  children: React.ReactNode;
};

export const Layout = ({ children }: LayoutProps) => {
  return <div className="flex flex-row w-full relative justify-start">{children}</div>;
};
