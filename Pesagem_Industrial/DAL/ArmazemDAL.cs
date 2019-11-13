using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pesagem_Industrial.DAL
{
    public class ArmazemDAL : IArmazemDAL
    {
        private PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        public IEnumerable<Armazem> ListarArmazens()
        {
            try
            {
                return db.Armazens.ToList();
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