import { Status } from "./enums/Status";

export interface Todo {
  id: number;
  title: string;
  description: string;
  status: Status;
  createdAt: Date;
}
