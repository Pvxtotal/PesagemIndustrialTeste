using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Pesagem_Industrial.DAL
{
    public class ArmazemDAL : IArmazemDAL
    {
        public IEnumerable<Armazem> ListarArmazens()
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
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

            }

        }

        public Armazem Detalhes(int? id)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    return db.Armazens.Find(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }

        }

        public void InserirArmazem(Armazem armazem)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Armazens.Add(armazem);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void EditarArmazem(Armazem armazem)
        {
            using(PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Set<Armazem>().AddOrUpdate(armazem);
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ExcluirArmazem(Armazem armazem)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Armazens.Remove(armazem);
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }



    }
}