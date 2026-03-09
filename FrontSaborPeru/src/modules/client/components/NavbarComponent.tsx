import { Link } from "react-router-dom"
import "../styles/NavbarStyle.css"

export const NavbarComponent = () => {
    return (
    <nav className="Navigation-Bar">
        <ul className="List-Bar">
            <li>
                <Link to="/">Menú</Link>
            </li>
            <li>
                <input type="text" placeholder="Buscar"/>
            </li>
            <li>
                <Link to="/cart">Carrito de Compras</Link>
            </li>
        </ul>
    </nav>
    )
}