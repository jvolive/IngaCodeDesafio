import React from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { HomePage } from "../pages";
import { AuthProvider } from "../context/AuthContext";

export const AppRoutes: React.FC = () => {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Routes>
          <Route path="/homepage" element={<HomePage />} />
          <Route path="*" element={<Navigate to="/homepage" />} />
        </Routes>
      </AuthProvider>
    </BrowserRouter>
  );
};
