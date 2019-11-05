using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public class ProdutoDAL
    {
        private static PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        public static void InserirProduto(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }

    
    }
}