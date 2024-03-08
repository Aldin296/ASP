using Microsoft.EntityFrameworkCore;
using PosTestUebung_Autor.Models;

namespace PosTestUebung_Autor.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DBSet
        public DbSet<Autor> Autoren { get; set; }
        public DbSet<Buch> Buecher { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
