import { useContext } from "react";
import { Table, Button, Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import CartContext from "../context/CartContext";

export default function Cart() {
  const { cart, dispatch } = useContext(CartContext); // <-- fix
  const { items, total } = cart;
  const navigate = useNavigate();

  if (!items.length)
    return <h3 className="text-center mt-5">Cart is empty</h3>;

  return (
    <Container className="p-3">
      <h2>Your Cart</h2>

      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Name</th>
            <th>Qty</th>
            <th>Price</th>
            <th>Subtotal</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {items.map((i) => (
            <tr key={i.id}>
              <td>{i.name}</td>
              <td>{i.qty}</td>
              <td>₹{i.price.toFixed(2)}</td>
              <td>₹{(i.price * i.qty).toFixed(2)}</td>
              <td>
                <Button
                  variant="danger"
                  size="sm"
                  onClick={() =>
                    dispatch({ type: "REMOVE_ITEM", payload: i.id })
                  }
                >
                  Remove
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      <h4>Total: ₹{total.toFixed(2)}</h4>
      <Button onClick={() => navigate("/checkout")}>
        Proceed to Checkout
      </Button>
    </Container>
  );
}
