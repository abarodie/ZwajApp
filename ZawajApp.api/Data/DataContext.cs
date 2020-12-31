using Microsoft.EntityFrameworkCore;
using ZawajApp.api.Models;

namespace ZawajApp.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Value> Values { get; set; }
    }
}