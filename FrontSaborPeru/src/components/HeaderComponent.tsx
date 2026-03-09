import carritoCompra from '../assets/carritoCompras.svg'
import '../styles/HeaderStyle.css'

export const HeaderComponent = () => {
    return(
        <header className='header-container'>
            <section>
                <h1>Sabor Perú</h1>
            </section>
            <section>
                <img src={carritoCompra} alt="Carrito de Compras" />
            </section>
        </header>
    )
}