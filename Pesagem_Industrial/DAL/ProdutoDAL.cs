using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;
using System.Data.Entity.Migrations;
using System.IO;
using System.Diagnostics;
using System.Data.Entity;

namespace Pesagem_Industrial.DAL
{
    public class ProdutoDAL : IProdutoDAL
    {

        public void InserirProduto(Produto produto)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                produto.DataCadastro = DateTime.Now;
                try
                {
                    db.Produtos.Add(produto);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



        }

        public IEnumerable<Produto> ListarProdutos()
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    var produtos = db.Produtos.Include(x => x.Armazem).Include(x => x.Unidade).Include(x => x.Grupo);
                    return produtos.ToList();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

        }

        public Produto EncontrarId(int? id)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                return db.Produtos.Find(id);
            }

        }

        public void EditarProduto(Produto produto)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                db.Database.Log = message => Debug.Write(message);
                produto.DataCadastro = db.Produtos.Find(produto.Id).DataCadastro;
                db.Set<Produto>().AddOrUpdate(produto);
                db.SaveChanges();
            }

        }

        public void ExcluirProduto(Produto produto)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                try
                {
                    var prod = db.Produtos.Where(x => x.Id == produto.Id).FirstOrDefault();
                    db.Produtos.Remove(prod);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }


    }
}