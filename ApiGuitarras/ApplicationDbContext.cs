using ApiGuitarras.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiGuitarras
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Guitarra> Guitarras { get; set; }

        public DbSet<Tienda> Tiendas { get; set; }
    }
}
