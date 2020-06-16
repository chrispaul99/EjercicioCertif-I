using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;
using BEUEjercicio.Transactions;
using BEUEjercicio.Utils;

namespace PryEjercicio.Controllers
{
    public class MatriculasController : Controller
    {
        private Entities db = new Entities();
        // GET: Matriculas
        public ActionResult Index()
        {
            ViewBag.Title = "Listado";
            return View(MatriculaBLL.List());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.tipo = new SelectList(MatriculaBLL.ListEnum("tipo"));
            ViewBag.estado = new SelectList(MatriculaBLL.ListEnum("estado"));
            ViewBag.idalumno = new SelectList(AlumnoBLL.List(), "idalumno", "nombres");
            ViewBag.idmateria = new SelectList(MateriaBLL.List(), "idmateria", "nombre");
            return View();
        }

        // POST: Matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmatricula,fecha,costo,estado,tipo,idalumno,idmateria")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                matricula = MatriculaBLL.TransforEnumCreate(matricula);
                MatriculaBLL.Create(matricula);
                return RedirectToAction("Index");
            }
            MatriculaBLL.TransforEnum(matricula);
            ViewBag.tipo = new SelectList(MatriculaBLL.ListEnum("tipo"),matricula.tipo);
            ViewBag.estado = new SelectList(MatriculaBLL.ListEnum("estado"),matricula.estado);
            ViewBag.idalumno = new SelectList(AlumnoBLL.List(), "idalumno", "nombres", matricula.idalumno);
            ViewBag.idmateria = new SelectList(MateriaBLL.List(), "idmateria", "nombre", matricula.idmateria);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            MatriculaBLL.TransforEnum(matricula);
            ViewBag.tipo = new SelectList(MatriculaBLL.ListEnum("tipo"), matricula.tipo);
            ViewBag.estado = new SelectList(MatriculaBLL.ListEnum("estado"), matricula.estado);
            ViewBag.idalumno = new SelectList(AlumnoBLL.List(), "idalumno", "nombres", matricula.idalumno);
            ViewBag.idmateria = new SelectList(MateriaBLL.List(), "idmateria", "nombre", matricula.idmateria);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmatricula,fecha,costo,estado,tipo,idalumno,idmateria")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                matricula = MatriculaBLL.TransforEnumCreate(matricula);
                MatriculaBLL.Update(matricula);
                return RedirectToAction("Index");
            }
            MatriculaBLL.TransforEnum(matricula);
            ViewBag.tipo = new SelectList(MatriculaBLL.ListEnum("tipo"), matricula.tipo);
            ViewBag.estado = new SelectList(MatriculaBLL.ListEnum("estado"), matricula.estado);
            ViewBag.idalumno = new SelectList(AlumnoBLL.List(), "idalumno", "nombres", matricula.idalumno);
            ViewBag.idmateria = new SelectList(MateriaBLL.List(), "idmateria", "nombre", matricula.idmateria);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatriculaBLL.Delete(id);
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
