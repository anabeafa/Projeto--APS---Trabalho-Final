using Microsoft.EntityFrameworkCore;
namespace ProjetoAna.Models

{
   public class MyDbContext : DbContext
   {
       public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
       {
       }
       public DbSet<Cliente> Cliente {get; set;}
       public DbSet<Vendedor> Vendendor {get; set;}
       public DbSet<Produto> Produto {get;set;}
       public DbSet<Marca> Marca {get; set;}
       public DbSet<Item> Item {get; set;}
       public DbSet<Pagamento>Pagamento {get; set;}
       public DbSet<TipoDePagamento>TipoDePagamento {get;set;}
       public DbSet<NotaDeVenda> NotaDeVenda{get; set;}
       public DbSet<Transportadora> Transportadora {get; set;}
  
   }
}
