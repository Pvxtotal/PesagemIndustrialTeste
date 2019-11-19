using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {

        public IEnumerable<Usuario> ListarUsuarios()
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                return db.Usuarios.ToList();
            }
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                Util.UtilSenha util = new Util.UtilSenha();

                usuario.Senha = util.GerarHash(usuario.Senha);

                try
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public void ExcluirUsuario(Usuario usuario)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    var user = db.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();
                    db.Usuarios.Remove(user);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public Usuario Logar(Usuario usuario)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                var op = db.Usuarios.Where(x => x.Username == usuario.Username).FirstOrDefault();
                if(op is null)
                {
                    return null;
                }
                string passDB = op.Senha;
                Util.UtilSenha util = new Util.UtilSenha();
                bool validacao = util.Verificar(passDB, usuario.Senha);

                if (validacao == true)
                {
                    return op;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}