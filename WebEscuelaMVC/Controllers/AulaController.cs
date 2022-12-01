using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using WebEscuelaMVC.Context;
using WebEscuelaMVC.Models;


namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller


    {

        //crear una instancia del context
        private EscuelaDBMVCContext context = new EscuelaDBMVCContext();
        // GET: Aula
        public ActionResult Index()  //ActionResult abarca retornos de todo tipo
                                     //Si quisieramos reemplazar un archivo.. ponemos FileResult
                                     //Si quisieramos reemplazar una vista.. ViewResult 


        {

            return View(); //podríamos también retornar json, pdf, html, javascript, etc.
        }




        [ChildActionOnly]
        public ActionResult _AulaGallery(int number = 0)
        {
            List<Aula> aulas;
            if (number == 0)
            {
                aulas = context.Aulas.ToList();
            }
            else
            {
                aulas = (
                from p in context.Aulas
                orderby p.Estado descending
                select p).Take(number).ToList();
            }
            return PartialView("_AulaGallery", aulas);


        }







        // GET: Aula/Create
        public ActionResult Create()
        {
            Aula aula = new Aula();

            return View("Register", aula);
        }



        //POST /Aula/Create
        [HttpPost]
        public ActionResult Create (Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Aulas.Add(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Register", aula);  //Nombre de la vista y objeto
            }
        }


        // GET: Details
 


        public ActionResult Details(int id)
        {
            Aula aula = context.Aulas.Find(id);

            if (aula == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Detalle", aula);
            }

        }

        // GET: /Aula/Edit/id 
        [HttpGet]
        public ActionResult Edit(int id)
        {

            Aula aula = context.Aulas.Find(id);

            if (aula == null)
            {
                return HttpNotFound();

            }

            return View("Edit", aula);

        }

    

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed (int id, Aula aula)
        {
            Aula aulaaux = context.Aulas.Find(id);

            if (aulaaux != null)
            {

                if (ModelState.IsValid)
                {
                    aula.AulaId = id;
                    context.Aulas.AddOrUpdate (aula);
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return RedirectToAction("Index");



        }


        // GET: /Aula/Delete/id 
        [HttpGet]
        public ActionResult Delete(int id)
        {

            Aula aula = context.Aulas.Find(id);

            if (aula == null)
            {
                return HttpNotFound();

            }

            return View("Delete", aula);

        }

     



        // POST: /Aula/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula != null)
            {
                context.Aulas.Remove(aula);
                context.SaveChanges();
            }

            return RedirectToAction("Index");

        }



    }
}