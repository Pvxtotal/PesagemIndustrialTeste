using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public class GrupoDAL : IGrupoDAL
    {
        PesagemIndustrialConnect db = new PesagemIndustrialConnect();
        public IEnumerable<Grupo> ListarGrupos()
        {
            try
            {
                return db.Grupos.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}