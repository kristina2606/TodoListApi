import React, { useContext, useEffect, useState } from "react";
import { FilterStatus } from "../models/enums/FilterStatus";
import { todoService } from "../service/TodoService";
import { PlusLg } from "react-bootstrap-icons";
import { Todo } from "../models/Todo";
import CreateTodo from "../components/CreateTodo";
import TodoItem from "../components/TodoItem";
import TodoFilter from "../components/TodoFilter";
import { filterByStatus } from "../utils";
import { ModalContext } from "../context/ModalContext";

interface TodosPageProps {
  todos: Todo[];
  setTodos: React.Dispatch<React.SetStateAction<Todo[]>>;
}

const TodosPage: React.FC<TodosPageProps> = ({ todos, setTodos }) => {
  const [filteredTodos, setFilteredTodos] = useState<Todo[]>([]);
  const [selectedStatus, setSelectedStatus] = useState<FilterStatus>(
    FilterStatus.All
  );
  const { modal, open, close } = useContext(ModalContext);

  const filterTodosByStatus = (status: FilterStatus) => {
    const filtered = todos.filter((todo) =>
      filterByStatus(status, todo.status)
    );
    setFilteredTodos(filtered);
  };

  const handleFilterChange = (status: FilterStatus) => {
    setSelectedStatus(status);
  };

  useEffect(() => {
    filterTodosByStatus(selectedStatus);
    todoService
      .getTodos()
      .then((data) => setTodos(data))
      .catch((error) => console.error("Error fetching todos:", error));
  }, [selectedStatus, todos]);

  return (
    <div className="card border-0">
      <div className="card-body">
        <h1 className="card-title text-center text-black fw-bold">My Todos</h1>
        <div className="row pt-4 pb-2">
          <TodoFilter
            handleFilterChange={handleFilterChange}
            selectedStatus={selectedStatus}
          />
          <div className="col-6 text-end">
            <button onClick={open} className="btn btn-primary">
              <PlusLg /> Add new task
            </button>
          </div>
        </div>
        {modal && <CreateTodo onClose={close} setTodos={setTodos} />}

        <table className="table table-hover mt-0">
          <thead></thead>
          <tbody>
            {filteredTodos.map((todo) => (
              <TodoItem key={todo.id} todo={todo} setTodos={setTodos} />
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default TodosPage;
