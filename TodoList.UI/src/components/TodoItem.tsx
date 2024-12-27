import React, { ChangeEvent, useState } from "react";
import { Todo } from "../models/Todo";
import { Status } from "../models/enums/Status";
import { getStatusColor } from "../utils";
import { todoService } from "../service/TodoService";

interface TodoItemProps {
  todo: Todo;
  setTodos: React.Dispatch<React.SetStateAction<Todo[]>>;
}

const TodoItem: React.FC<TodoItemProps> = ({ todo, setTodos }) => {
  const [newStatus, setNewStatus] = useState(todo.status);

  const handleStatusChange = async (e: ChangeEvent<HTMLSelectElement>) => {
    const selectedStatus = parseInt(e.target.value, 10) as Status;

    setNewStatus(selectedStatus);
    try {
      await todoService.updateStatus(todo.id, selectedStatus);
      const updatedTodos = await todoService.getTodos();
      setTodos(updatedTodos);
    } catch (error) {
      console.error("Error updating todo's status:", error);
    }
  };

  return (
    <>
      <tr className="table-light">
        <td>
          <strong> {todo.title}</strong>
          <br />
          <em className="text-secondary">
            {todo.description.length > 40
              ? `${todo.description.substring(0, 40)}...`
              : todo.description}
          </em>
        </td>
        <td>
          <select
            className={`btn ${getStatusColor(todo.status)} `}
            id="status"
            value={newStatus}
            onChange={handleStatusChange}
          >
            <option value="1">Todo</option>
            <option value="2">In Progress</option>
            <option value="3">Completed</option>
          </select>
        </td>
        <td className="text-end text-body-tertiary">
          <em>{new Date(todo.createdAt).toLocaleTimeString()}</em>
          <br />
          <em>{new Date(todo.createdAt).toLocaleDateString()}</em>
        </td>
      </tr>
    </>
  );
};

export default TodoItem;
