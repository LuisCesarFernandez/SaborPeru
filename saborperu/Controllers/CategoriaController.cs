using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saborperu.Data;
using saborperu.DTOS.Categoria;
using saborperu.Entities;

namespace saborperu.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly RestaurantDbContext _db;

        public CategoriaController(RestaurantDbContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaReadDTO>>> GetCategorias() 
        {
            var categorias = await _db.Categorias
                .Select(p => new CategoriaReadDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                })
                .ToListAsync();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria(int id) 
        {
            var categoria = await _db.Categorias.FindAsync(id);
            if (categoria == null) 
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(CategoriaCreateDTO dto)
        {
            var categoria = new Categoria 
            {
                Nombre = dto.Nombre,
            };

            _db.Categorias.Add(categoria);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCategoria), 
                new { id = categoria.Id }, 
                categoria);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PathCategoria(int id, CategoriaPatchDTO dto) 
        {
            var categoria = await _db.Categorias.FindAsync(id);
            if (categoria == null) 
            {
                return NotFound("Catagoria no encontrada");
            }

            var nombre = await _db.Categorias.AnyAsync
                (n => n.Nombre == dto.Nombre);

            if (nombre!) 
            {
                return BadRequest("Nombre no encontrado");
            }
            categoria.Nombre = dto.Nombre;
            
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
