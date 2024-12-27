import Reactэ from "react";
import { FilterStatus } from "../models/enums/FilterStatus";

interface TodoFilterProps {
  handleFilterChange: (status: FilterStatus) => void;
  selectedStatus: FilterStatus;
}

const TodoFilter: React.FC<TodoFilterProps> = ({
  handleFilterChange,
  selectedStatus,
}) => {
  return (
    <div className="col-6 d-flex">
      <ul className="list-group list-group-horizontal-sm">
        {Object.values(FilterStatus).map((status) => (
          <li
            key={status}
            className={`list-group-item ${
              selectedStatus === status
                ? "active text-white bg-primary"
                : "bg-body-tertiary"
            }`}
            onClick={() => handleFilterChange(status)}
          >
            {status}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TodoFilter;
