using System.Collections.Generic;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public interface IGrupoDAL
    {
        IEnumerable<Grupo> ListarGrupos();
    }
}