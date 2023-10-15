using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TADuc_TravelMVC.Models
{
    public class GioHang
    {
        QLTravelModel db = new QLTravelModel();
        public int iMaTour { get; set; }
        public string sTenTour { get; set; }
        public string sHinhAnh { get; set; }
        public double dGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MaSanPham)
        {
            iMaTour = MaSanPham;
            Tour sp = db.Tour.Single(n => n.MaTour == iMaTour);
            sTenTour = sp.TenTour;
            sHinhAnh = sp.HinhAnh;
            dGia = double.Parse(sp.Gia.ToString());
            iSoLuong = 1;
        }
    }
}