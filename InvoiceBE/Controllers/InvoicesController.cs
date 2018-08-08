using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InvoiceBE.ContextDB;
using InvoiceBE.Models;

namespace InvoiceBE.Controllers
{
    public class InvoicesController : ApiController
    {
        private InvoiceContext db = new InvoiceContext();

        // GET: api/Invoices
        public IQueryable<Invoice> GetInvoices()
        {
            return db.Invoices;
        }

        // GET: api/Invoices/5
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult GetInvoice(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        // PUT: api/Invoices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvoice(int id, Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoice.InvoiceID)
            {
                return BadRequest();
            }

            db.Entry(invoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Invoices
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult PostInvoice(Invoice invoice )
       {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Invoice Factura = new Invoice();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("EmployeeID", invoice.EmployeeID),
                new SqlParameter("ClientID", invoice.ClientID),
                new SqlParameter("Date", invoice.Date),
                new SqlParameter("Remark", " "),
            };

            try
            {
                Factura = db.Database.SqlQuery<Invoice>("Crear_Factura @EmployeeID, @ClientID, @Date, @Remark", parameters.ToArray()).SingleOrDefault();

                if(invoice.Details == null)
                {
                    return Json(Factura);
                }
                else
                {
                    List<SqlParameter> parameters2 = new List<SqlParameter>();
                    foreach (var detalle in invoice.Details) 
                    {
                        parameters2.Add(new SqlParameter("DetailID", Factura.InvoiceID));
                        parameters2.Add(new SqlParameter("ProductID", detalle.ProductID));
                        parameters2.Add(new SqlParameter("Quantity", detalle.Quantity));


                        
                        db.Database.SqlQuery<InvoiceDetails>("Crear_Factura_Detalle @DetailID, @ProductID, @Quantity ", parameters2.ToArray()).ToList();

                        parameters2.Clear();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return Json(Factura);

            // return CreatedAtRoute("DefaultApi", new { id = invoice.InvoiceID }, invoice);
        }

        // DELETE: api/Invoices/5
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult DeleteInvoice(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }

            db.Invoices.Remove(invoice);
            db.SaveChanges();

            return Ok(invoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoiceExists(int id)
        {
            return db.Invoices.Count(e => e.InvoiceID == id) > 0;
        }
    }
}