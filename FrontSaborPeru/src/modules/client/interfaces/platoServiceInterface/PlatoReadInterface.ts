export interface PlatoReadInterface {
    id:number,
    nombre:string,
    precio:number,
    imagenurl:string,
    disponible:boolean,
    categoria:string
}

export interface CartContextInterface extends PlatoReadInterface {
    cantidad: number,
}