﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_crudMVC_csharp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_crudMVC_csharp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto db;

        //usar o bando de dados no controlador - passo ele via injeção de dependencia
        public UsuariosController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: UsuariosController
        public ActionResult Index(string texto_input)
        {
            if (string.IsNullOrEmpty(texto_input))
            {
                return View(db.USUARIOS.ToList());
            }
            else
            {
                return View(db.USUARIOS.Where(a => a.Login.Contains(texto_input) || a.Nome.Contains(texto_input)));
            }

          
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios collection)
        {
            try
            {
                db.USUARIOS.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.USUARIOS.Where(a => a.Id == id).FirstOrDefault());
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuarios collection)
        {
            try
            {
                db.USUARIOS.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            db.USUARIOS.Remove(db.USUARIOS.Where(a=>a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
