namespace saborperu.Entities
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; } = false;
        public string? ImagenUrl { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
