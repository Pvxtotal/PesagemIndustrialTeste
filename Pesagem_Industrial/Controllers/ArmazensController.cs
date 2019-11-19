using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;
using Pesagem_Industrial.Util;
using Pesagem_Industrial.DAL;

namespace Pesagem_Industrial.Controllers
{
    [Session]
    public class ArmazensController : Controller
    {
        private PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        // GET: Armazens
        public ActionResult Index()
        {
            IArmazemDAL dal = new ArmazemDAL();
            return View(dal.ListarArmazens());
        }
    

        // GET: Armazens/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Local")] Armazem armazem)
        {
            if (ModelState.IsValid)
            {
                IArmazemDAL dal = new ArmazemDAL();
                dal.InserirArmazem(armazem);
                return RedirectToAction("Index");
            }

            return View(armazem);
        }

        // GET: Armazens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armazem armazem = db.Armazens.Find(id);
            if (armazem == null)
            {
                return HttpNotFound();
            }
            return View(armazem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Local")] Armazem armazem)
        {
            if (ModelState.IsValid)
            {
                IArmazemDAL dal = new ArmazemDAL();
                dal.EditarArmazem(armazem);
                return RedirectToAction("Index");
            }
            return View(armazem);
        }

        // GET: Armazens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armazem armazem = db.Armazens.Find(id);
            if (armazem == null)
            {
                return HttpNotFound();
            }
            return View(armazem);
        }

        // POST: Armazens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armazem armazem = db.Armazens.Find(id);
            IArmazemDAL dal = new ArmazemDAL();
            dal.ExcluirArmazem(armazem);
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
