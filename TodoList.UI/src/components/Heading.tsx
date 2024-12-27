import { Calendar2RangeFill } from "react-bootstrap-icons";
import { useNavigate } from "react-router-dom";

const Heading = () => {
  const navigate = useNavigate();

  const handleReturnHomePage = () => {
    navigate("/");
  };

  return (
    <header>
      <nav className="navbar navbar-expand-sm border-bottom box-shadow mb-3">
        <div className="container-fluid">
          <button
            className="navbar-brand nav-link"
            onClick={handleReturnHomePage}
          >
            <Calendar2RangeFill /> Todo
          </button>
          <div className="d-sm-inline-flex">
            <button className="nav-link text-dark">Register</button>
            <div className="mx-2"></div>
            <button className="nav-link text-dark">Login</button>
          </div>
        </div>
      </nav>
    </header>
  );
};

export default Heading;
