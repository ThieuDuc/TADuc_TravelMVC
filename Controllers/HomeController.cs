using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using TADuc_TravelMVC.Models;

namespace TADuc_TravelMVC.Controllers
{
    public class HomeController : Controller
    {
        QLTravelModel db = new QLTravelModel();
        public ActionResult Index(int? page,String SearchString = "")
        {
            
            var tour = from danhmuc in db.Tour
                       select danhmuc;
            //var DanhMuclist = new QuanLyHangModel().DanhMuc.ToList();
            if (!String.IsNullOrEmpty(SearchString))
            {
                // LOC TEN DANH MUC THEO SEARCHSTRING
                tour = tour.Where(s => s.TenTour.Contains(SearchString));
            }
            if (page == null) page = 1;
            tour = tour.OrderBy(x => x.MaTour);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            // tra ve ket qua su dung phan trang 
            return View(tour.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult AllTour()
        {
            var AllTour = db.Tour.Take(6).OrderBy(x =>
            x.MaTour).ToList();
            return PartialView(AllTour);
        }
        public ActionResult TourTrangChuPartial()
        {
            var TourTrangChu = db.Tour.Take(6).OrderBy(x =>
            x.MaTour).ToList();
            return PartialView(TourTrangChu);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}