using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pos.Models;

namespace pos.Controllers
{
    public class facturasController : Controller
    {
        private ProyectoPapaEntities db = new ProyectoPapaEntities();

        // GET: facturas
        public ActionResult Index()
        {
            var factura = db.factura.Include(f => f.cliente).Include(f => f.producto).Include(f => f.vendedor);
            return View(factura.ToList());
        }

        // GET: facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            ViewBag.Id_cliente = new SelectList(db.cliente, "Id", "RazonSocial");
            ViewBag.Id_producto = new SelectList(db.producto, "Id", "nombre");
            ViewBag.Id_vendedor = new SelectList(db.vendedor, "Id", "nombre");
            return View();
        }

        // POST: facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fecha,Id_cliente,Id_vendedor,Id_producto")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_cliente = new SelectList(db.cliente, "Id", "RazonSocial", factura.Id_cliente);
            ViewBag.Id_producto = new SelectList(db.producto, "Id", "nombre", factura.Id_producto);
            ViewBag.Id_vendedor = new SelectList(db.vendedor, "Id", "nombre", factura.Id_vendedor);
            return View(factura);
        }

        // GET: facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_cliente = new SelectList(db.cliente, "Id", "RazonSocial", factura.Id_cliente);
            ViewBag.Id_producto = new SelectList(db.producto, "Id", "nombre", factura.Id_producto);
            ViewBag.Id_vendedor = new SelectList(db.vendedor, "Id", "nombre", factura.Id_vendedor);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fecha,Id_cliente,Id_vendedor,Id_producto")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_cliente = new SelectList(db.cliente, "Id", "RazonSocial", factura.Id_cliente);
            ViewBag.Id_producto = new SelectList(db.producto, "Id", "nombre", factura.Id_producto);
            ViewBag.Id_vendedor = new SelectList(db.vendedor, "Id", "nombre", factura.Id_vendedor);
            return View(factura);
        }

        // GET: facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factura factura = db.factura.Find(id);
            db.factura.Remove(factura);
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
