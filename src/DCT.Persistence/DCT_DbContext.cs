using DCT.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCT.Persistence
{
    public partial class DCT_DbContext : DbContext
    {
        public DCT_DbContext(DbContextOptions<DCT_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Municipality> Municipalities { get; set; }
    }
}
