using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDoDungTreEm.Models;

namespace WebAppDoDungTreEm.Controllers
{
    public class HomeController : Controller
    {
        QLTreEmDataContext db = new QLTreEmDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HienThiNhom()
        {
            return PartialView(db.Nhoms.ToList());
        }

        public ActionResult HienThiLoaiTheoNhom(string mn)
        {
            List<LoaiSanPham> list = db.LoaiSanPhams.Where(t => t.MaNhom == mn).ToList();
            return PartialView(list);
        }

        public ActionResult HienThiSanPhamTheoLoai(string ml)
        {
            LoaiSanPham l = db.LoaiSanPhams.FirstOrDefault(t => t.MaLoai == ml);
            //ViewBag.TenLoai = l.ThuongHieu;
            List<SanPham> list = db.SanPhams.Where(t => t.MaLoai == ml).ToList();
            return View(list);
        }
        public ActionResult ChiTietSP(string msp)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(t => t.MaSP == msp);
            LoaiSanPham l = db.LoaiSanPhams.FirstOrDefault(t => t.MaLoai == sp.MaLoai);
            //ViewBag.TenLoai = l.ThuongHieu;
            return View(sp);
        }
    }
}