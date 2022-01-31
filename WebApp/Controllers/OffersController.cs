using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OffersController : Controller
    {
        private CarMarketEntities db = new CarMarketEntities();

        // GET: Offers
        public ActionResult IndexC(string criteria)
        {
            var oglas = new List<Offer>();

            if (!string.IsNullOrEmpty(criteria))
            {

                oglas = db.Offers.Include(o => o.Category1).Where(o => o.Category == 1 && (o.Model.Contains(criteria) || o.Desription.Contains(criteria) || o.Distance.ToString().Contains(criteria) || o.Year.ToString().Contains(criteria) || o.Power_HP_.ToString().Contains(criteria) || o.Power_KW_.ToString().Contains(criteria))).ToList();
            }
            else
            {
                oglas = db.Offers.Include(o => o.Category1).Where(o => o.Category == 1).ToList();
            }
            return View(oglas);
        }

        // GET: Offers
        public ActionResult IndexMA(string criteria)
        {
            var oglas = new List<Offer>();

            if (!string.IsNullOrEmpty(criteria))
            {

                oglas = db.Offers.Include(o => o.Category1).Where(o => o.Category == 2 && (o.Model.Contains(criteria) || o.Desription.Contains(criteria) || o.Distance.ToString().Contains(criteria) || o.Year.ToString().Contains(criteria) || o.Power_HP_.ToString().Contains(criteria) || o.Power_KW_.ToString().Contains(criteria))).ToList();
            }
            else
            {
                oglas = db.Offers.Include(o => o.Category1).Where(o => o.Category == 2).ToList();
            }
            return View(oglas);
        }

        // GET: Offers
        public ActionResult IndexCV(string criteria)
        {
            var oglas = new List<Offer>();

            if (!string.IsNullOrEmpty(criteria))
            {

                oglas = db.Offers.Include(o => o.Category1).Where(o => o.Category == 3 && (o.Model.Contains(criteria) || o.Desription.Contains(criteria) || o.Distance.ToString().Contains(criteria) || o.Year.ToString().Contains(criteria) || o.Power_HP_.ToString().Contains(criteria) || o.Power_KW_.ToString().Contains(criteria))).ToList();
            }
            else
            {
                oglas = db.Offers.Include(o => o.Category1).Where(o => o.Category == 3).ToList();
            }
            return View(oglas);
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Categories, "ID", "CetgoryName");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Offer offer)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                try
                {
                    fileName = Path.GetFileNameWithoutExtension(offer.Image.FileName);
                    string extension = Path.GetExtension(offer.Image.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmddssfff") + extension;
                    offer.Picture = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    offer.Image.SaveAs(fileName);
                }
                catch (Exception)
                {
                    offer.Picture = "~/Images/NoImage.png";
                }
               
                db.Offers.Add(offer);
                db.SaveChanges();
                switch (offer.Category)
                {
                    case 2: return RedirectToAction("IndexMA");
                    case 3: return RedirectToAction("IndexCV");
                    default:
                        return RedirectToAction("IndexC");
                       
                }
            }

            ViewBag.Category = new SelectList(db.Categories, "ID", "CetgoryName", offer.Category);
            return View(offer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var offer = db.Offers.Find(id);
            if (offer!=null)
            {
               

                db.Offers.Remove(offer);
                db.SaveChanges();
                switch (offer.Category)
                {
                    case 2: return RedirectToAction("IndexMA");
                    case 3: return RedirectToAction("IndexCV");
                    default:
                        return RedirectToAction("IndexC");

                }
            }

            return View(offer);
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
