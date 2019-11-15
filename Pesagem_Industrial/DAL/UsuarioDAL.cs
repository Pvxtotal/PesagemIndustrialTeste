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
        PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return db.Usuarios.ToList();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            //Util.UtilSenha util = new Util.UtilSenha();

            //usuario.Senha = util.GerarHash(usuario.Senha);


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

        public void ExcluirUsuario(int id)
        {
            try
            {
                Usuario usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Usuario Logar(Usuario usuario)
        {
            usuario = db.Usuarios.Where(x => x.Username == usuario.Username && x.Senha == usuario.Senha).FirstOrDefault();

            if(usuario != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }


        }
    }
}