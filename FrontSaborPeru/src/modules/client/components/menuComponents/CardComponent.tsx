import { useCart } from "../../../../context/CardContext"
import { api } from "../../../../api/api.service";
import type { PlatoReadInterface } from "../../interfaces/platoServiceInterface/PlatoReadInterface"

export const CardComponent = (plato:PlatoReadInterface) => {

    const {addToCart} = useCart();
    const {nombre, precio, imagenurl, disponible, categoria} = plato;
    return(
        <div>
            <section>
                <img src={`${api}${imagenurl}`} alt="ComidaXD" />
                <h3>{nombre}</h3>
                <h3>Precio: S/.{precio}</h3>
                { disponible === false ? <h3>Agotado</h3>:<h3>Disponible</h3>}
                <h3>{categoria}</h3>
            </section>
            <section>
                <button 
                onClick={()=>addToCart(plato)} 
                disabled={!disponible}>Agregar al menú</button>
            </section>
        </div>
    )
}