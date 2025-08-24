import { Form, Button, Container } from "react-bootstrap";

export default function ContactUs() {
  return (
    <Container className="p-4">
      <h2>Contact Us</h2>
      <Form>
        <Form.Group className="mb-3">
          <Form.Label>Your Email</Form.Label>
          <Form.Control placeholder="name@example.com" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Message</Form.Label>
          <Form.Control as="textarea" rows={4} />
        </Form.Group>
        <Button type="submit">Send</Button>
      </Form>
    </Container>
  );
}
