import { FilterStatus } from "./models/enums/FilterStatus";
import { Status } from "./models/enums/Status";

export const getStatusColor = (status: Status) => {
  switch (status) {
    case Status.Completed:
      return "btn-outline-success";
    case Status.InProgress:
      return "btn-outline-warning";
    case Status.Todo:
      return "btn-outline-info";
    default:
      return "btn-outline-secondary";
  }
};

export const filterByStatus = (status: FilterStatus, todoStatus: Status) => {
  switch (status) {
    case FilterStatus.Active:
      return todoStatus !== Status.Completed;
    case FilterStatus.Todo:
      return todoStatus === Status.Todo;
    case FilterStatus.InProgress:
      return todoStatus === Status.InProgress;
    case FilterStatus.Completed:
      return todoStatus === Status.Completed;
    default:
      return true;
  }
};
