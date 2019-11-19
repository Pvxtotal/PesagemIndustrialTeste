using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public class GrupoDAL : IGrupoDAL
    {
        public IEnumerable<Grupo> ListarGrupos()
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
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
            }
            
        }


        public void InserirGrupo(Grupo grupo)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Grupos.Add(grupo);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void EditarGrupo(Grupo grupo)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Set<Grupo>().AddOrUpdate(grupo);
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void ExcluirGrupo(Grupo grupo)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Grupos.Remove(grupo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}