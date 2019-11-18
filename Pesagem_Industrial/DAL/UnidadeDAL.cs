using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public class UnidadeDAL : IUnidadeDAL
    {
        public SelectList ListarMedidas(string tipo)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                List<Unidade> medidasPrimario = new List<Unidade>();

                medidasPrimario = db.Unidades.Where(x => x.Tipo == tipo).ToList();

                SelectList medidas = new SelectList(medidasPrimario, "Id", "Medida");

                return medidas;
            }

        }

        public IEnumerable<Unidade> ListarTodos()
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    return db.Unidades.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public void Inserir(Unidade unidade)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Unidades.Add(unidade);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Editar(Unidade unidade)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Set<Unidade>().AddOrUpdate(unidade);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Excluir(Unidade unidade)
        {
            using(PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    db.Unidades.Remove(unidade);
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