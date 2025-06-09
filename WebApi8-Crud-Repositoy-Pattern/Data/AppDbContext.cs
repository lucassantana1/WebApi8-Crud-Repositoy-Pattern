using Microsoft.EntityFrameworkCore;
using WebApi8_Crud_Repositoy_Pattern.Models;

namespace WebApi8_Crud_Repositoy_Pattern.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
