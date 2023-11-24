using EcommerceAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Voucher_Claim> voucher_Claims { get; set; }
    }
}
