namespace saborperu.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public List<DetallePedido>  Detalles { get; set; }
    }
}
