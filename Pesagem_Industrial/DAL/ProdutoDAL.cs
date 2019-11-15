using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public class ProdutoDAL: IProdutoDAL
    {
        private static PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        public void InserirProduto(Produto produto)
        {
            produto.DataCadastro = DateTime.Now;
            try
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

        public IEnumerable<Produto> ListarProdutos()
        {
            try
            {
                return db.Produtos.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Produto EncontrarId(int? id)
        {
            return db.Produtos.Find(id);
        }  

        public void EditarProduto(Produto produto)
        {
            var prod = db.Produtos.Find(produto.Id);
            prod.Armazem_Id = produto.Armazem_Id;
            prod.Descricao = produto.Descricao;
            prod.Grupo_Id = produto.Grupo_Id;
            prod.Origem = produto.Origem;
            prod.Unidade_Id = produto.Unidade_Id;
            db.SaveChanges();
        }

        public void ExcluirProduto(int id)
        {
            try
            {
                var produto = db.Produtos.Find(id);
                db.Produtos.Remove(produto);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}