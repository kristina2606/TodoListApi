import React from "react";
import { useNavigate } from "react-router-dom";

const HomePage: React.FC = () => {
  const navigate = useNavigate();

  const handleGetStarted = () => {
    navigate("/todos");
  };

  return (
    <div className="text-center">
      <h1 className="mb-4">Welcome to Your Todo List</h1>
      <p className="lead">
        Stay organized and manage your tasks effectively with our simple and
        intuitive Todo application.
      </p>
      <button className="btn btn-lg btn-info" onClick={handleGetStarted}>
        Get Started
      </button>
    </div>
  );
};

export default HomePage;
