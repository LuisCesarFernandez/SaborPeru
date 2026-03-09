import { createContext, useState,type ReactNode, useContext } from "react";
import type { CartContextInterface, PlatoReadInterface } from "../modules/client/interfaces/platoServiceInterface/PlatoReadInterface";

interface CartContextType {
    cart: CartContextInterface[],
    addToCart: (producto: PlatoReadInterface) => void,
    removeFromCart: (id: number) => void,
    total: number
}

const CartContext = createContext<CartContextType | undefined>(undefined);

export const CartProvider = ({children}:{children:ReactNode}) => {
    const [cart, setCart] = useState<CartContextInterface[]>([]);

    const addToCart = (producto:PlatoReadInterface) => {
        setCart(prevCart => {
            const itemExist = prevCart.find(item => item.id === producto.id)
            if (itemExist) {
                //En caso exista aumentamos la cantidad.
                return prevCart.map(item=>item.id === producto.id ? {...item, cantidad: item.cantidad + 1}:item)
            }
            //Si no existe, lo agregamos.
            return [...prevCart, {...producto, cantidad: 1}]
        });
    };

    const removeFromCart = (id:number) => {
        setCart(prevCart => prevCart.filter(item => item.id !== id));
    };

    const total = cart.reduce((acc, item) => acc + (item.precio * item.cantidad),0);

    return (
        <CartContext.Provider value={{cart, addToCart, removeFromCart, total}}>
            {children}
        </CartContext.Provider>
    )
};

//Hook personalizado.
export const useCart = () => {
    const context = useContext(CartContext);
    if (!context) throw new Error("Use context debe usarse dentro de un cardProvider");
    return context;
}