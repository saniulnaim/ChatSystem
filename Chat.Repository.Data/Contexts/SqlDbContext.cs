using Chat.Repository.Core.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace Chat.Repository.Data.Contexts
{
    public class SqlDbContext : DbContext
    {
        #region HR
        public DbSet<ChatHistory> ChatHistories { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion HR


        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
    }
}
