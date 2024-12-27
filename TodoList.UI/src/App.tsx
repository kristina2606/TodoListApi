import React, { useEffect, useState } from "react";
import {
  BrowserRouter,
  HashRouter,
  Route,
  Routes,
  useNavigate,
} from "react-router-dom";
import "./App.css";
import Footer from "./components/Footer";
import Heading from "./components/Heading";
import HomePage from "./pages/HomePage";
import TodosPage from "./pages/TodosPage";
import { Todo } from "./models/Todo";

const App: React.FC = () => {
  const [todos, setTodos] = useState<Todo[]>([]);

  return (
    <BrowserRouter basename="/api">
      <div className="App">
        <Heading />
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route
            path="/todos"
            element={<TodosPage todos={todos} setTodos={setTodos} />}
          />
        </Routes>
        <Footer />
      </div>
    </BrowserRouter>
  );
};

export default App;
