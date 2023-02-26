using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea_CRUDTbUsuarios.Models;

namespace Tarea_CRUDTbUsuarios.Controllers
{
    public class UsuariosController : Controller
    {
        private DB_USUARIOSEntities db = new DB_USUARIOSEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tbUsuarios = db.V_USARIOS_INDEX;
            return View(tbUsuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.usu_UsuCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe");
            ViewBag.usu_UsuModif = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usu_Id,usu_Nambe,usu_Apellido,usu_UsuarioAlias,usu_Contra,usu_EsAdmin,usu_UsuCrea,usu_FechaCrea,usu_UsuModif,usu_FechaModif,usu_Estado")] tbUsuarios tbUsuarios)
        {
            ModelState.Remove("usu_FechaCrea");
            ModelState.Remove("usu_UsuModif");
            ModelState.Remove("usu_FechaModif");
            ModelState.Remove("usu_Estado");
            if (ModelState.IsValid)
            {
                //int usuariocreacion = Int32.Parse(Session["Usuario"].ToString());
                bool EsAdmin = tbUsuarios.usu_EsAdmin;

                db.UDP_USUARIOS_INSERT(tbUsuarios.usu_Nambe, tbUsuarios.usu_Apellido, tbUsuarios.usu_UsuarioAlias, tbUsuarios.usu_Contra, EsAdmin , 1).ToString();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usu_UsuCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe", tbUsuarios.usu_UsuCrea);
            ViewBag.usu_UsuModif = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe", tbUsuarios.usu_UsuModif);
            return View(tbUsuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.usu_UsuCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe", tbUsuarios.usu_UsuCrea);
            ViewBag.usu_UsuModif = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe", tbUsuarios.usu_UsuModif);
            return View(tbUsuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usu_Id,usu_Nambe,usu_Apellido,usu_UsuarioAlias,usu_Contra,usu_EsAdmin,usu_UsuCrea,usu_FechaCrea,usu_UsuModif,usu_FechaModif,usu_Estado")] tbUsuarios tbUsuarios)
        {
            ModelState.Remove("usu_UsuCrea");
            ModelState.Remove("usu_FechaCrea");
            ModelState.Remove("usu_FechaModif");
            ModelState.Remove("usu_Estado");
            ModelState.Remove("usu_Contra");

            if (ModelState.IsValid)
            {
                //int UsuarioModi = Int32.Parse(Session["Usuario"].ToString());

                db.UDP_EDITAR_USUARIOS(tbUsuarios.usu_Id, tbUsuarios.usu_Nambe, tbUsuarios.usu_Apellido, tbUsuarios.usu_UsuarioAlias, tbUsuarios.usu_EsAdmin, 1).ToString();
                
                return RedirectToAction("Index");
            }
            ViewBag.usu_UsuCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe", tbUsuarios.usu_UsuCrea);
            ViewBag.usu_UsuModif = new SelectList(db.tbUsuarios, "usu_Id", "usu_Nambe", tbUsuarios.usu_UsuModif);
            return View(tbUsuarios);
        }

        public ActionResult Delete(int id)
        {
            //int UsuarioModifica = Int32.Parse(Session["Usuario"].ToString());
            db.UDP_ELIMINAR(id, 1).ToString();
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
        //    if (tbUsuarios == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbUsuarios);
        //}

        //// POST: Usuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
        //    db.UDP_ELIMINAR(id, Int32.Parse(Session["Usuario"].ToString())).ToString();
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult EliminarRegistro(int id)
        //{
        //    using (var db = new DB_USUARIOSEntities())
        //    {
        //        var registro = db.tbUsuarios.Find(id);
        //        if (registro == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        db.UDP_ELIMINAR(id, Int32.Parse(Session["Usuario"].ToString())).ToString();
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

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
