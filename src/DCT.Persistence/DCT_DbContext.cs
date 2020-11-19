using DCT.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DCT.Persistence
{
    public partial class DCT_DbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DCT_DbContext(DbContextOptions<DCT_DbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Municipality> Municipalities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
