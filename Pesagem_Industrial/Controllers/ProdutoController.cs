using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pesagem_Industrial.Models;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.DAL;
using Pesagem_Industrial.Util;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Pesagem_Industrial.Controllers
{
    [Session]
    public class ProdutoController : Controller
    {
        private PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        [HttpGet]
        public ActionResult InserirProduto()
        {
            Produto produto = new Produto();
            produto.Unidade = Util.ListarMedidas.Listar();
            IArmazemDAL armazemDal = new ArmazemDAL();
            IGrupoDAL grupoDal = new GrupoDAL();
            ViewBag.Grupos = grupoDal.ListarGrupos();
            ViewBag.Armazens = armazemDal.ListarArmazens();
            ViewBag.Medidas = produto.Unidade.Tipos;

            return View();
        }

        [HttpPost]
        public ActionResult InserirProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                IProdutoDAL dal = new ProdutoDAL();
                dal.InserirProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Index()
        {
            IProdutoDAL dal = new ProdutoDAL();
            return View(dal.ListarProdutos());
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult ListarMedidas(string tipo)
        {
            IUnidadeDAL unidadeDAL = new UnidadeDAL();

            SelectList lista = unidadeDAL.ListarMedidas(tipo);

            return Json(lista);
        }

        public ActionResult Editar(int? id)
        {
            IProdutoDAL dal = new ProdutoDAL();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = new Produto();
            produto = dal.EncontrarId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            produto.Unidade = Util.ListarMedidas.Listar();

            IArmazemDAL armazemDal = new ArmazemDAL();

            IGrupoDAL grupoDal = new GrupoDAL();

            ViewBag.Grupos = grupoDal.ListarGrupos();
            ViewBag.Armazens = armazemDal.ListarArmazens();
            ViewBag.Medidas = produto.Unidade.Tipos;

            return View(produto);

        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {

            if (produto.Unidade_Id == null)
            {
                ModelState.AddModelError(string.Empty, "Erro!");
            }

            if (ModelState.IsValid)
            {
                IProdutoDAL dal = new ProdutoDAL();
                dal.EditarProduto(produto);

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            TempData["Produto"] = produto;
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public  ActionResult Delete(int id)
        {
            Produto produto = new Produto();
            produto = TempData["Produto"] as Produto;
            IProdutoDAL dal = new ProdutoDAL();
            dal.ExcluirProduto(produto);
            return RedirectToAction("Index");
        }


    }
}