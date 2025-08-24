// src/Pages/Products.jsx
import { useEffect, useState, useContext } from "react";
import {
  Card,
  Button,
  Row,
  Col,
  Spinner,
  Alert,
  Container,
  Badge,
} from "react-bootstrap";
import CartContext from "../context/CartContext";
import { useNavigate } from "react-router-dom";

export default function Products() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const { dispatch } = useContext(CartContext);
  const token = localStorage.getItem("token");
  const navigate = useNavigate();

  useEffect(() => {
    fetch("https://localhost:7294/api/Products", {
      headers: { Authorization: `Bearer ${token}` },
    })
      .then((r) => (r.ok ? r.json() : Promise.reject(r.status)))
      .then(setProducts)
      .catch(console.error)
      .finally(() => setLoading(false));
  }, [token]);

  if (loading)
    return (
      <div className="text-center mt-5">
        <Spinner animation="border" />
      </div>
    );

  if (!products.length)
    return <Alert variant="warning">No products available.</Alert>;

  const grouped = products.reduce((acc, p) => {
    const cat = p.category?.name ?? "Other";
    if (!acc[cat]) acc[cat] = [];
    acc[cat].push(p);
    return acc;
  }, {});

  const categoryNames = Object.keys(grouped).sort();

  return (
    <Container className="p-3">
      <h2 className="mb-4 text-center">Products by Category</h2>

      {categoryNames.map((cat) => (
        <div key={cat} className="mb-5">
          <h4 className="mb-3">
            {cat}{" "}
            <Badge pill bg="secondary">
              {grouped[cat].length}
            </Badge>
          </h4>

          <Row xs={1} sm={2} md={3} lg={4} className="g-4">
            {grouped[cat].map((p) => (
              <Col key={p.id}>
                <Card className="h-100 shadow-sm">
                  {p.imageUrl && (
                    <Card.Img
                      variant="top"
                      src={p.imageUrl}
                      alt={p.name}
                      style={{ height: "200px", objectFit: "cover" }}
                    />
                  )}

                  <Card.Body className="d-flex flex-column">
                    <Card.Title>{p.name}</Card.Title>
                    <Card.Text className="mb-2">
                      ₹{p.price.toFixed(2)}
                    </Card.Text>

                    <Button
                      variant="primary"
                      className="mt-auto"
                      onClick={() => dispatch({ type: "ADD_ITEM", payload: p })}
                    >
                      Add to Cart
                    </Button>
                  </Card.Body>
                </Card>
              </Col>
            ))}
          </Row>
        </div>
      ))}

      <div className="text-center mt-4">
        <Button
          variant="success"
          onClick={() => navigate("/cart")}
          className="me-2"
        >
          Go to Cart
        </Button>
        <Button variant="warning" onClick={() => navigate("/checkout")}>
          Proceed to Checkout
        </Button>
      </div>
    </Container>
  );
}
