using Microsoft.EntityFrameworkCore;
using PedidoAZ.Models;

namespace PedidoAZ.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public DbSet<PedidoModel> Pedido { get; set; }
    }
}
