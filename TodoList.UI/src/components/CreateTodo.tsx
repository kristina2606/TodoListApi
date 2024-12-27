import React, { useState } from "react";
import { todoService } from "../service/TodoService";
import { Todo } from "../models/Todo";
import Modal from "./Modal";

interface CreateTodoProps {
  onClose: () => void;
  setTodos: React.Dispatch<React.SetStateAction<Todo[]>>;
}

const CreateTodo: React.FC<CreateTodoProps> = ({ onClose, setTodos }) => {
  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    try {
      const newTodo = await todoService.createTodo(title, description);
      if (newTodo) {
        onClose();
        setTodos((prev) => [...prev, newTodo]);
      }
    } catch (error) {
      console.error("Error creating todo:", error);
    }
  };

  return (
    <Modal title="Create new task">
      <form onSubmit={handleSubmit}>
        <div className="form-floating py-2">
          <input
            className="form-control"
            id="title"
            onChange={(event) => setTitle(event.target.value)}
          />
          <label>Title</label>
        </div>
        <div className="form-floating py-2">
          <textarea
            className="form-control"
            id="description"
            style={{ height: "200px" }}
            onChange={(event) => setDescription(event.target.value)}
          ></textarea>
          <label>Description</label>
        </div>

        <div className="row">
          <div className="col-3 offset-6">
            <button
              type="submit"
              className="btn btn-outline-primary form-control"
            >
              Add
            </button>
          </div>
          <div className="col-3 ">
            <button className="btn btn-dark form-control" onClick={onClose}>
              Back
            </button>
          </div>
        </div>
      </form>
    </Modal>
  );
};

export default CreateTodo;
