import React, { lazy, Suspense } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import { Container, Spinner } from 'react-bootstrap';
import PrivateRoute from './components/ProtectedRoute.jsx';
import Navbar from './components/Navbar.jsx';


const Home = lazy(() => import('./Pages/Home.jsx'));
const Login = lazy(() => import('./Pages/Login.jsx'));
const ContactUs = lazy(() => import('./Pages/ContactUs.jsx'));
const ProductList = lazy(() => import('./Pages/Products.jsx')); // updated Products.jsx shows all products
const Cart = lazy(() => import('./Pages/Cart.jsx'));
const Checkout = lazy(() => import('./Pages/Checkout.jsx'));

export default function App() {
  return (
    <>
      <Navbar />
      <Container className="mt-4">
        <Suspense fallback={<div className="text-center"><Spinner animation="border" /></div>}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<Login />} />
            <Route path="/contact" element={<ContactUs />} />
            <Route
              path="/products"
              element={
                <PrivateRoute>
                  <ProductList />
                </PrivateRoute>
              }
            />
            <Route path="/cart" element={<Cart />} />
            <Route path="/checkout" element={<Checkout />} />
            <Route path="*" element={<Navigate to="/" />} />
          </Routes>
        </Suspense>
      </Container>
    </>
  );
}
