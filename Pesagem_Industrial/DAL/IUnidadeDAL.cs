using Pesagem_Industrial.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Pesagem_Industrial.DAL
{
    public interface IUnidadeDAL
    {
        SelectList ListarMedidas(string tipo);
        IEnumerable<Unidade> ListarTodos();
        void Inserir(Unidade unidade);
        void Editar(Unidade unidade);
        void Excluir(Unidade unidade);
    }
}