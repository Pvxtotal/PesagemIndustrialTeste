using System.Collections.Generic;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public interface IUsuarioDAL
    {
        void CadastrarUsuario(Usuario usuario);
        void ExcluirUsuario(Usuario usuario);
        IEnumerable<Usuario> ListarUsuarios();
        Usuario Logar(Usuario usuario);
    }
}