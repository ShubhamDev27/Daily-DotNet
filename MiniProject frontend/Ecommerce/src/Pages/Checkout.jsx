import { useContext } from "react";
import { Container, Alert } from "react-bootstrap";
import CartContext from "../context/CartContext";

export default function Checkout() {
  const { cart } = useContext(CartContext);

  return (
    <Container className="p-4">
      <h2>✅ Thank you for your purchase!</h2>
      {cart.items.length ? (
        <>
          <p>Here is what you bought:</p>
          <ul>
            {cart.items.map(i => (
              <li key={i.id}>
                {i.qty} x {i.name}  ₹{(i.price * i.qty).toFixed(2)}
              </li>
            ))}
          </ul>
          <h4>Total paid: ₹{cart.total.toFixed(2)}</h4>
        </>
      ) : (
        <Alert variant="warning">
          No items in your cart. Maybe you refreshed the page or navigated here directly.
        </Alert>
      )}
    </Container>
  );
}
