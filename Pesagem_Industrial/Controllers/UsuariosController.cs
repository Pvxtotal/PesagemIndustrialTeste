﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;
using Pesagem_Industrial.DAL;


namespace Pesagem_Industrial.Controllers
{
    public class UsuariosController : Controller
    {
        private PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        // GET: Usuarios
        public ActionResult Index()
        {
            IUsuarioDAL dal = new UsuarioDAL();
            return View(dal.ListarUsuarios());
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            ViewBag.Perfis = usuario.Perfis;
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Senha,Perfil")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                IUsuarioDAL dal = new UsuarioDAL();
                dal.CadastrarUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IUsuarioDAL dal = new UsuarioDAL();
            dal.ExcluirUsuario(id);
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string senha)
        {
            IUsuarioDAL dal = new UsuarioDAL();
            Usuario usuario = new Usuario();
            usuario.Username = username;
            usuario.Senha = senha;
            usuario = dal.Logar(usuario);
            if(usuario == null)
            {
                ViewBag.Erro = "Usuario ou Senha invalida";
                return View();
            }

            Session["UserID"] = usuario.Id;

            return RedirectToAction("Index", "Produto");

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