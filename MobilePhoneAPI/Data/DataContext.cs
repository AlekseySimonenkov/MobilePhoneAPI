using Microsoft.EntityFrameworkCore;
namespace MobilePhoneAPI.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MobilePhone> MobilePhones => Set<MobilePhone>();
    }
}
