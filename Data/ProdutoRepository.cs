using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    public class ProdutoRepository : IProdutoRepositorio
    {
        private readonly ProdutoContexto _contexto;
      
        public ProdutoRepository(ProdutoContexto contexto)
        {
            _contexto = contexto;
        }
        public void Editar(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            _contexto.SaveChanges();
        }

        public void Excluir(Produto produto)
        {
            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();   
        }

        public void Inserir(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
        }

        public Produto Obter(int id)
        {
            return _contexto.Produtos.Find(id);
        }

        public IEnumerable<Produto> Obter()
        {
            return _contexto.Produtos.ToList();
        }
    }
}