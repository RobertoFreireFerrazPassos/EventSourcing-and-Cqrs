using Microsoft.EntityFrameworkCore;
using Receipt.Api.Entities;

namespace Receipt.Api.Infra.DataAccess
{
    public class ReceiptContext : DbContext
    {
        public DbSet<StoredEventEntity> Events { get; set; }
        public ReceiptContext(DbContextOptions<ReceiptContext> options) : base(options) { }
    }
}
