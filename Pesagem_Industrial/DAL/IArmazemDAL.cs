using System.Collections.Generic;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public interface IArmazemDAL
    {
        Armazem Detalhes(int? id);
        void InserirArmazem(Armazem armazem);
        IEnumerable<Armazem> ListarArmazens();
    }
}