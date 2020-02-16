using System.Collections.Generic;

namespace API.Data
{
    public interface IProdutoRepositorio
    {
        void Inserir(Produto produto);
        void Editar(Produto produto);
        void Excluir(Produto produto);
        Produto Obter(int id);
        IEnumerable<Produto> Obter();

    }
}