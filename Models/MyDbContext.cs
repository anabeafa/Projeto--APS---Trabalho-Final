using Microsoft.EntityFrameworkCore;
namespace ProjetoAna.Models

{
   public class MyDbContext : DbContext
   {
       public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
       {
       }
       public DbSet<Cliente> Cliente {get; set;}
   }
}
