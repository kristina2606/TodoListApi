import axios from "axios";
import { Status } from "../models/enums/Status";
import { Todo } from "../models/Todo";

const apiUrl = "https://localhost:7196/api/todos";

const api = axios.create({
  baseURL: apiUrl,
  headers: {
    "Content-Type": "application/json",
  },
});

export const todoService = {
  getTodos: async () => {
    try {
      const response = await api.get("/");
      return response.data;
    } catch (error) {
      console.error("Error fetching todos:", error);
    }
  },

  getTodo: async (id: number) => {
    try {
      const response = await api.get(`/${id}`);
      return response.data;
    } catch (error) {
      console.error("Error fetching todos:", error);
    }
  },

  createTodo: async (title: string, description: string) => {
    try {
      const response = await api.post<Todo>("/", { title, description });
      return response.data;
    } catch (error) {
      console.error("Error creating todo:", error);
    }
  },

  updateTodo: async (id: number, title: string, description: string) => {
    try {
      await api.put(`/${id}`, { id, title, description });
      const updatedTodo = await todoService.getTodo(id);
      return updatedTodo;
    } catch (error) {
      console.error("Error updating todo:", error);
    }
  },

  updateStatus: async (id: number, status: Status) => {
    try {
      await api.patch(`/${id}/status`, { id, status });
    } catch (error) {
      console.error("Error updating todo's status:", error);
    }
  },

  deleteTodo: async (id: number) => {
    try {
      await api.delete(`/${id}`);
    } catch (error) {
      console.error("Error deleting todo:", error);
    }
  },
};
