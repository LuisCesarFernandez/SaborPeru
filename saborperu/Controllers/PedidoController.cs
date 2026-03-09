using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saborperu.Data;
using saborperu.Entities;

namespace saborperu.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly RestaurantDbContext _db;

        public PedidoController(RestaurantDbContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos() 
        {
            return await _db.Pedidos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido(int id) 
        {
            var pedido = await _db.Pedidos.FindAsync(id);

            if (pedido == null) 
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido) 
        {
            _db.Pedidos.Add(pedido);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPedido), 
                new { id = pedido.Id }, 
                pedido);
        }
    }
}
