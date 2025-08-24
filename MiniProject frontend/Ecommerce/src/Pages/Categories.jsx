import { useEffect, useState } from "react";
import { ListGroup, Spinner, Alert, Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

export default function Categories() {
  const [cats, setCats] = useState([]);
  const [loading, setLoading] = useState(true);
  const token = localStorage.getItem("token");
  const navigate = useNavigate();

  useEffect(() => {
    fetch("https://localhost:7294/api/Categories", {
      headers: { Authorization: `Bearer ${token}` },
    })
      .then(r => r.ok ? r.json() : Promise.reject(r.status))
      .then(setCats).catch(console.error).finally(() => setLoading(false));
  }, [token]);

  if (loading) return <Spinner animation="border" className="mt-4" />;
  if (!cats.length) return <Alert>No categories!</Alert>;

  return (
    <Container className="p-3">
      <h2>Select a category</h2>
      <ListGroup>
        {cats.map(c => (
          <ListGroup.Item
            key={c.id}
            action
            onClick={() => navigate(`/products/${c.id}`, { state: c.name })}
          >
            {c.name}
          </ListGroup.Item>
        ))}
      </ListGroup>
    </Container>
  );
}
