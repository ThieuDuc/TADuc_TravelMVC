using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using TADuc_TravelMVC.Common;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TADuc_TravelMVC.Models;

namespace TADuc_TravelMVC.Areas.Admin.Controllers
{
    public class NguoiDungsController : Controller
    {
        private QLTravelModel db = new QLTravelModel();
        //GET: Admin/NguoiDungs/Login
        public ActionResult Login()
        {
            return View();
        }
        //POST: Admin/NguoiDungs/Login
        [HttpPost]
        public ActionResult Login(FormCollection userForm)
        {
            string tendangnhapform = userForm["TenDangNhap"].ToString();
            string matkhauForm = userForm["MatKhau"].ToString();
            var matkhauMD5 = MaHoaMD5.GetMD5(matkhauForm);
            var nguoiDung = db.NguoiDung.SingleOrDefault(x =>x.TenDangNhap.Equals(tendangnhapform) && x.MatKhau.Equals(matkhauMD5));
            if (nguoiDung != null)
            {
                Session["user"] = nguoiDung;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Fail = "Tài khoản hoặc mật khẩu không chính xác.";
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
        // GET: Admin/NguoiDungs
        public ActionResult Index()
        {
            var nguoiDung = db.NguoiDung.Include(n => n.PhanQuyen);
            return View(nguoiDung.ToList());
        }

        // GET: Admin/NguoiDungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Create
        public ActionResult Create()
        {
            ViewBag.MaQuyen = new SelectList(db.PhanQuyen, "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: Admin/NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaND,HoTen,DiaChi,Email,SoDienThoai,TenDangNhap,MatKhau,AnhDaiDien,MaQuyen")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.MatKhau = (MaHoaMD5.GetMD5(nguoiDung.MatKhau));
                db.Configuration.ValidateOnSaveEnabled = false;
                db.NguoiDung.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaQuyen = new SelectList(db.PhanQuyen, "MaQuyen", "TenQuyen", nguoiDung.MaQuyen);
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaQuyen = new SelectList(db.PhanQuyen, "MaQuyen", "TenQuyen", nguoiDung.MaQuyen);
            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaND,HoTen,DiaChi,Email,SoDienThoai,TenDangNhap,MatKhau,AnhDaiDien,MaQuyen")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.MatKhau = (MaHoaMD5.GetMD5(nguoiDung.MatKhau));
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(nguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaQuyen = new SelectList(db.PhanQuyen, "MaQuyen", "TenQuyen", nguoiDung.MaQuyen);
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            db.NguoiDung.Remove(nguoiDung);
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
