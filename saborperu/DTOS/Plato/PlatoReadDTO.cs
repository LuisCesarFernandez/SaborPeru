using saborperu.Entities;

namespace saborperu.DTOS.Plato
{
    public class PlatoReadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string? ImagenUrl { get; set; }
        public bool Disponible { get; set; } = false;
        public string Categoria { get; set; }
    }
}
