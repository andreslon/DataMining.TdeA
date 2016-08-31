using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataMining.WebApp.Models;

namespace DataMining.WebApp.Controllers
{
    public class ValoresController : Controller
    {
        private TdeAEntities db = new TdeAEntities();

        // GET: Valores
        public ActionResult Index()
        {
            return View(db.Tbl_Valores.ToList());
        }

        // GET: Valores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Valores tbl_Valores = db.Tbl_Valores.Find(id);
            if (tbl_Valores == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Valores);
        }

        // GET: Valores/Create
        public ActionResult Create()
        {
            return View();
        }
        // Import: Valores/Import
        public ActionResult Import()
        {
            var res = db.ImportDataValues();
            return View("Index", db.Tbl_Valores.ToList());
        }
        // POST: Valores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor1,Valor2")] Tbl_Valores tbl_Valores)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Valores.Add(tbl_Valores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Valores);
        }

        // GET: Valores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Valores tbl_Valores = db.Tbl_Valores.Find(id);
            if (tbl_Valores == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Valores);
        }

        // POST: Valores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor1,Valor2")] Tbl_Valores tbl_Valores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Valores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Valores);
        }

        // GET: Valores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Valores tbl_Valores = db.Tbl_Valores.Find(id);
            if (tbl_Valores == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Valores);
        }

        // POST: Valores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Valores tbl_Valores = db.Tbl_Valores.Find(id);
            db.Tbl_Valores.Remove(tbl_Valores);
            db.SaveChanges();
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
