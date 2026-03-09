using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saborperu.Data;
using saborperu.Entities;

namespace saborperu.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly RestaurantDbContext _db;

        public DetallePedidoController(RestaurantDbContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedidos() 
        {
            return await _db.DetallePedidos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedido(int id) 
        {
            var detallePedido = await _db.DetallePedidos.FindAsync(id);

            if (detallePedido == null) 
            {
                return NotFound();
            }

            return Ok(detallePedido);
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detallePedido) 
        {
            _db.DetallePedidos.Add(detallePedido);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetDetallePedido), 
                new { id = detallePedido.Id }, 
                detallePedido);
        }
    }
}
