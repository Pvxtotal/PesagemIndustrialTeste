using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pesagem_Industrial.DAL;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;
using Pesagem_Industrial.Util;

namespace Pesagem_Industrial.Controllers
{
    [Session]
    public class UnidadesController : Controller
    {
        private PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        // GET: Unidades
        public ActionResult Index()
        {
            IUnidadeDAL dal = new UnidadeDAL();
            return View(dal.ListarTodos());
        }


        // GET: Unidades/Create
        public ActionResult Create()
        {
            Unidade unidade = new Unidade();
            unidade = ListarMedidas.Listar();
            ViewBag.Medidas = unidade.Tipos;
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Medida,Tipo")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                IUnidadeDAL dal = new UnidadeDAL();
                dal.Inserir(unidade);
                return RedirectToAction("Index");
            }

            return View(unidade);
        }

        // GET: Unidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return HttpNotFound();
            }
            return View(unidade);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Medida,Tipo")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                IUnidadeDAL dal = new UnidadeDAL();
                dal.Editar(unidade);
                return RedirectToAction("Index");
            }
            return View(unidade);
        }

        // GET: Unidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return HttpNotFound();
            }
            return View(unidade);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidade unidade = db.Unidades.Find(id);
            IUnidadeDAL dal = new UnidadeDAL();
            dal.Excluir(unidade);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
