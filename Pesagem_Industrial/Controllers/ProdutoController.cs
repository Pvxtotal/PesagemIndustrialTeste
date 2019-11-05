using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pesagem_Industrial.Models;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.DAL;

namespace Pesagem_Industrial.Controllers
{
    public class ProdutoController : Controller
    {
        private PesagemIndustrialConnect db = new PesagemIndustrialConnect();
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InserirProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserirProduto(Produto produto)
        {
            if(ModelState.IsValid)
            {
                ProdutoDAL.InserirProduto(produto);
            }
            return View();
        }

        public ActionResult ListarProduto()
        {
            var produtosFerro = db.Produtos.Where(x => x.Origem == "Ferro").FirstOrDefault();
            return View(produtosFerro);
        }
    }
}