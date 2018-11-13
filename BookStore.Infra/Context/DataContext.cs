using BookStore.Domain.Entities;
using BookStore.Infra.Map;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());
        }
    }
}