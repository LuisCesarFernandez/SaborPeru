using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saborperu.Data;
using saborperu.DTOS.Plato;
using saborperu.Entities;

namespace saborperu.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class PlatoController : ControllerBase
    {
        private readonly RestaurantDbContext _db;

        public PlatoController(RestaurantDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatoReadDTO>>> GetPlato()
        {
            var platos = await _db.Platos
                .Include(p => p.Categoria)
                .Select(p => new PlatoReadDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    ImagenUrl = p.ImagenUrl,
                    Disponible = p.Disponible,
                    Categoria = p.Categoria.Nombre
                }).ToListAsync();

            return Ok(platos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Plato>>> GetPlatos(int id)
        {
            var plato = await _db.Platos.FindAsync(id);

            if (plato == null)
            {
                return NotFound();
            }
            return Ok(plato);
        }

        [HttpPost]
        public async Task<ActionResult<PlatoCreateDTO>> PostPlato(PlatoCreateDTO dto)
        {

            var plato = new Plato
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                ImagenUrl = dto.UrlImage,
                Disponible = dto.Disponible,
                CategoriaId = dto.CategoriaId,
            };

            _db.Platos.Add(plato);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPlato),
                new { id = plato.Id },
                plato);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchPlato(int id, [FromBody] PlatoPatchDTO dto)
        {
            var plato = await _db.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound("Plato no encontrado");
            }

            var nombre = await _db.Platos
                .AnyAsync(n => n.ImagenUrl == dto.ImagenUrl);

            if (!nombre) 
            {
                return BadRequest("Nombre no existe.");
            }

            plato.ImagenUrl = dto.ImagenUrl;

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
