import { useCart } from "../../../context/CardContext";
import { ShoppingCartLayout } from "../layouts/ShoppingLayout";
export const ShoppingCartPage = () => {
  const { cart, removeFromCart, total } = useCart();
  return (
    <ShoppingCartLayout>
      <div>
        <h2>Pedido</h2>
        {cart.length === 0 ? (
          <p>No hay nada por pedir.</p>
        ) : (
          <ul>
            {cart.map((item) => (
              <li>
                {item.nombre} - x{item.cantidad} = S/.
                {item.precio * item.cantidad}
                <button onClick={() => removeFromCart(item.id)}>
                  Eliminar
                </button>
              </li>
            ))}
          </ul>
        )}
        <hr />
        <h3>Monto total a pagar: S/.{total.toFixed(2)}</h3>
        <button disabled={cart.length === 0}>Confirmar Pedido</button>
      </div>
    </ShoppingCartLayout>
  );
};
