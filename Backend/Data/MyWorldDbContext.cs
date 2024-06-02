using BeachApi.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace BeachApi.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options) { }
        
         public required DbSet<Beach> Beach{get;set;}
    }

   
}
