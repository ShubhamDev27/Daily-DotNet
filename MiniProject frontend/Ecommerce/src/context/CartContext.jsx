import React, { createContext, useReducer } from "react";

const CartContext = createContext();

const initialState = { items: [], total: 0 };

function cartReducer(state, action) {
  switch (action.type) {
    case "ADD_ITEM": {
      const updated = [...state.items];
      const idx = updated.findIndex((i) => i.id === action.payload.id);
      if (idx !== -1) updated[idx].qty += 1;
      else updated.push({ ...action.payload, qty: 1 });

      const total = updated.reduce(
        (sum, i) => sum + i.price * i.qty,
        0
      );
      return { items: updated, total };
    }

    case "REMOVE_ITEM": {
      const updated = state.items.filter((i) => i.id !== action.payload);
      const total = updated.reduce(
        (sum, i) => sum + i.price * i.qty,
        0
      );
      return { items: updated, total };
    }

    case "CLEAR_CART":
      return initialState;

    default:
      return state;
  }
}

export function CartProvider({ children }) {
  const [cart, dispatch] = useReducer(cartReducer, initialState);
  return (
    <CartContext.Provider value={{ cart, dispatch }}>
      {children}
    </CartContext.Provider>
  );
}

export default CartContext;
