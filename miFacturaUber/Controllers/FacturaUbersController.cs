using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using miFacturaUber.DataAccess;
using miFacturaUber.Models;

namespace miFacturaUber.Controllers
{
    public class FacturaUbersController : Controller
    {
        private FacturaUberContext db = new FacturaUberContext();

        // GET: FacturaUbers
        public ActionResult Index()
        {
            return View(db.Factura.ToList());
        }

        // GET: FacturaUbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaUber facturaUber = db.Factura.Find(id);
            if (facturaUber == null)
            {
                return HttpNotFound();
            }
            return View(facturaUber);
        }

        // GET: FacturaUbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaUbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaUberID,TotalFactura,ComisionUber,SueldoChofer,Gasolina,PlanCelular,OtrosGastos,Rango")] FacturaUber facturaUber)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(facturaUber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facturaUber);
        }

        // GET: FacturaUbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaUber facturaUber = db.Factura.Find(id);
            if (facturaUber == null)
            {
                return HttpNotFound();
            }
            return View(facturaUber);
        }

        // POST: FacturaUbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaUberID,TotalFactura,ComisionUber,SueldoChofer,Gasolina,PlanCelular,OtrosGastos,Rango")] FacturaUber facturaUber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaUber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facturaUber);
        }

        // GET: FacturaUbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaUber facturaUber = db.Factura.Find(id);
            if (facturaUber == null)
            {
                return HttpNotFound();
            }
            return View(facturaUber);
        }

        // POST: FacturaUbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturaUber facturaUber = db.Factura.Find(id);
            db.Factura.Remove(facturaUber);
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
