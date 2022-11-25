using ApiGuitarras.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApiGuitarras
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Guitarra> Guitarras { get; set; }

        public DbSet<Tienda> Tiendas { get; set; }
    }
}
