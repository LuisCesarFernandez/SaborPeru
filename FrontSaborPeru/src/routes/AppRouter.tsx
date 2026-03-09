import { Route, Routes } from "react-router-dom"
import { MenuPage } from "../modules/client/pages/MenuPage"
import { ShoppingCartPage } from "../modules/client/pages/ShoppingcartPage"

export const AppRouter = () => {
    return(
        <Routes>
            <Route path="/" element={<MenuPage/>}/>
            <Route path="/cart" element={<ShoppingCartPage/>}/>
        </Routes>
    )
}