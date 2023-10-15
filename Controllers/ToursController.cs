using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TADuc_TravelMVC.Models;

namespace TADuc_TravelMVC.Controllers
{
    public class ToursController : Controller
    {
        private QLTravelModel db = new QLTravelModel();
        
        // GET: Tours
        public ActionResult Index()
        {
            var tour = db.Tour.Include(t => t.DanhMucTour);
            return View(tour.ToList());
        }
        public ActionResult ChiTietTour(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }
        public ActionResult Search(int? page, string SearchString ="", string ngayKhoiHanh = "")
        {
            var products = from chitiet in db.Tour select chitiet;
                           
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.TenTour.Contains(SearchString));
            }
            
             else if (!string.IsNullOrEmpty(ngayKhoiHanh))
            {
                var dtNgayKhoiHanh = DateTime.Parse(ngayKhoiHanh);
                products = products.Where(t => t.NgayKhoiHanh == dtNgayKhoiHanh);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            products = products.OrderBy(x => x.MaTour);
            //return View(products);
            if (page == null) page = 1;
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            // tra ve ket qua su dung phan trang 
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucTour, "MaDanhMuc", "DiaDiem");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTour,TenTour,NgayKhoiHanh,SoNgay,HinhAnh,Gia,MoTa,MaDanhMuc")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tour.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDanhMuc = new SelectList(db.DanhMucTour, "MaDanhMuc", "DiaDiem", tour.MaDanhMuc);
            return View(tour);
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucTour, "MaDanhMuc", "DiaDiem", tour.MaDanhMuc);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTour,TenTour,NgayKhoiHanh,SoNgay,HinhAnh,Gia,MoTa,MaDanhMuc")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucTour, "MaDanhMuc", "DiaDiem", tour.MaDanhMuc);
            return View(tour);
        }
        //public ActionResult TourTrangChuPartial()
        //{
        //    var TourTrangChu = db.Tour.Take(6).OrderBy(x =>
        //    x.MaTour).ToList();
        //    return PartialView(TourTrangChu);
        //}
        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tour.Find(id);
            db.Tour.Remove(tour);
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
