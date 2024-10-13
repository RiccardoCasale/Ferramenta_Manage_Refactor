using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace REST_03_EF_ferramenta.Models
{
    public class Context_Ferramenta : DbContext
    {

        public Context_Ferramenta (DbContextOptions<Context_Ferramenta> options) : base(options)
        {

        }

        public DbSet<Prodotto> Prodottos { get; set; }
        public DbSet<Reparto> Repartos { get; set; }
    }
}
