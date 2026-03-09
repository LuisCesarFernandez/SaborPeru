using saborperu.Entities;

namespace saborperu.DTOS.Plato
{
    public class PlatoCreateDTO
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string? UrlImage { get; set; }
        public bool Disponible { get; set; } = false;
        public int CategoriaId { get; set; }
    }
}
