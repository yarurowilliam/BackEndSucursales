using BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Context
{
    public class AplicationDbContext:DbContext 
    {
        public DbSet<Moneda> Monedas_TEST { get; set; }
        public DbSet<Usuario> Usuarios_TEST { get; set; }
        public DbSet<Sucursal> Sucursal_TEST { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
