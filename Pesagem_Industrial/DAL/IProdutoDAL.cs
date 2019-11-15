using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    interface IProdutoDAL
    {
        void InserirProduto(Produto produto);

        IEnumerable<Produto> ListarProdutos();

        Produto EncontrarId(int? id);

        void EditarProduto(Produto produto);

        void ExcluirProduto(int id);




    }
}
