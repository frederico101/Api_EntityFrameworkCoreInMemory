using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProdutoContexto : DbContext
    {
        public ProdutoContexto(DbContextOptions options)
              : base(options){}
        public DbSet<Produto> Produtos { get; set; }
    }
}