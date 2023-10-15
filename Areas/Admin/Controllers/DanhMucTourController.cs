using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using TADuc_TravelMVC.Models;

namespace TADuc_TravelMVC.Areas.Admin.Controllers
{
    public class DanhMucTourController : Controller
    {
        QLTravelModel db = new QLTravelModel();
        // GET: Admin/DanhMucTour
        public ActionResult Index(int?page,string searchString,string gender)
        {
            //if(Session["user"] == null)
            //{
            //    return RedirectToAction("Login");
            //}
            // lay toan bo danh sach 
            var danhmucTour = from danhmuc in db.DanhMucTour 
                              select danhmuc;
            // kiem tra chuoi searchString tu from tim kiem gui len co rong/null hay k 
            if (!String.IsNullOrEmpty(searchString))
            {
                // loc ten danh muc theo searchString 
                danhmucTour = danhmucTour.Where(s=>s.DiaDiem.Contains(searchString));
            }
            //var listDanhMuc = new QLTravelModel().DanhMucTour.ToList();
            // sap sep theo ma danh muc tang dan 
            danhmucTour = danhmucTour.OrderBy(x => x.MaDanhMuc);
            // PHAN TRANG 
            if (page == null) page = 1;
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            // tra ve ket qua su dung phan trang 
            return View(danhmucTour.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/DanhMucTour/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var context = new QLTravelModel();
            var danhmuctour = context.DanhMucTour.Find(id);
            if (danhmuctour == null)
            {
                return HttpNotFound();
            }
            return View(danhmuctour);
        }

        // GET: Admin/DanhMucTour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucTour/Create
        [HttpPost]
        public ActionResult Create(DanhMucTour model)
        {
            try
            {
                // TODO: Add insert logic here

                var context = new QLTravelModel();
                context.DanhMucTour.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DanhMucTour/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new QLTravelModel();
            var editing = context.DanhMucTour.Find(id);
            return View(editing);
            
        }

        // POST: Admin/DanhMucTour/Edit/5
        [HttpPost]
        public ActionResult Edit(DanhMucTour model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new QLTravelModel();
                var Olding = context.DanhMucTour.Find(model.MaDanhMuc);
                Olding.DiaDiem = model.DiaDiem;
                Olding.MoTa = model.MoTa;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DanhMucTour/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new QLTravelModel();
            var deleting = context.DanhMucTour.Find(id);
            return View(deleting);
        }

        // POST: Admin/DanhMucTour/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var context = new QLTravelModel();
                var deleting = context.DanhMucTour.Find(id);
                context.DanhMucTour.Remove(deleting);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
