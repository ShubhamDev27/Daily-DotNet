// src/components/LogoutButton.jsx
import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

export default function LogoutButton({ onLogout }) {
  const navigate = useNavigate();

  function handleLogout() {
    localStorage.removeItem("token");
    if (onLogout) onLogout(null);
    navigate("/");
  }

  return (
    <Button variant="outline-light" onClick={handleLogout}>
      Logout
    </Button>
  );
}
