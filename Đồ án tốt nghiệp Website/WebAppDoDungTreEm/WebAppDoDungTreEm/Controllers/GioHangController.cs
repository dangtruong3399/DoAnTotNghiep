using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDoDungTreEm.Models;

namespace WebAppDoDungTreEm.Controllers
{
    public class GioHangController : Controller
    {
        QLTreEmDataContext db = new QLTreEmDataContext();
        // GET: GioHang

        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstgiohang = Session["Giohang"] as List<GioHang>;
            if (lstgiohang == null)
            {
                lstgiohang = new List<GioHang>();
                Session["Giohang"] = lstgiohang;
            }
            return lstgiohang;
        }

        public ActionResult Themgiohang(string msp)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sp = lstGiohang.Find(n => n.MaSP == msp);
            if (sp == null)
            {
                sp = new GioHang(msp);
                lstGiohang.Add(sp);
            }
            else
            {
                sp.Soluong++;
            }
            return RedirectToAction("XemGioHang");
        }
        public ActionResult Xemgiohang()
        {
            List<GioHang> lstgiohang = Laygiohang();
            if (lstgiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.tongsoluong = tongsoluong();
            ViewBag.tongtien = tongtien();
            return View(lstgiohang);
        }
        private int tongsoluong()
        {
            int tong = 0;
            List<GioHang> lst = Session["Giohang"] as List<GioHang>;
            if (lst != null)
            {
                tong = lst.Sum(n => n.Soluong);
            }
            return tong;
        }
        private double tongtien()
        {
            double tong = 0;
            List<GioHang> lst = Session["Giohang"] as List<GioHang>;
            if (lst != null)
            {
                tong = lst.Sum(n => n.ThanhTien);
            }
            return tong;
        }
        public ActionResult Xoa1SPKhoiGio(string msp)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sp = lstGiohang.Find(n => n.MaSP == msp);
            lstGiohang.Remove(sp);
            return RedirectToAction("Xemgiohang");
        }
        public ActionResult XoaAllGioHang()
        {
            List<GioHang> lstGiohang = Laygiohang();
            lstGiohang.RemoveRange(0, lstGiohang.Count);
            return RedirectToAction("Xemgiohang");
        }
        public ActionResult ThongTinDatHang(FormCollection collection)
        {
            List<GioHang> lstGiohang = Laygiohang();
            
            List<string> soLuong = collection["SoLuong"].Split(',').ToList();
            List<string> maSP = collection["MaSP"].Split(',').ToList();
            
            foreach (GioHang gh in lstGiohang)
            {
                for (var i =0; i<maSP.Count; i++)
                {
                    if (gh.MaSP == maSP[i])
                    {
                        gh.Soluong = Int32.Parse(soLuong[i]);

                        var k1 = db.Khos.Where(x => x.MaSP == maSP[i]);
                        foreach (var kho in k1)
                        {
                            if (kho.SoLuong < gh.Soluong)
                            {
                                string msg = "Số lượng của " + gh.TenSP + " vượt quá " + kho.SoLuong;
                                TempData["message"] = msg;
                                return RedirectToAction("Xemgiohang");
                            }
                        }
                    }
                }
            }
            TaiKhoan kh = (TaiKhoan)Session["TaiKhoan"];
            if (kh != null)
            {
                return View(kh);
            }
            else
            {
                return RedirectToAction("DatHang", "GioHang");
            }
        }
        //
        public ActionResult DatHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DatHang(SanPham sanPham,FormCollection collection)
        {
            //Thêm Đơn hàng
            DonHang dh = new DonHang();
            TaiKhoan kh = (TaiKhoan)Session["TaiKhoan"];
            TempData["message"] = "";
            if (kh != null)
            {
                List<GioHang> gh = Laygiohang();
                dh.UserName = kh.UserName;
                dh.NgayDatHang = DateTime.Now;
                var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["ngaygiao"]);
                if (ngaygiao != "")
                {
                    dh.NgayGiao = DateTime.Parse(ngaygiao);
                }
                var phuongthucthanhtoan = Int32.Parse(collection["phuongthucthanhtoan"]);
                if (phuongthucthanhtoan == 1)
                {
                    dh.DaThanhToan = 1;
                }
                else
                {
                    dh.DaThanhToan = 0;
                }
                dh.TinhTrangGiaoHang = 0;
                dh.PhuongThucThanhToan = phuongthucthanhtoan;
                db.DonHangs.InsertOnSubmit(dh);
                db.SubmitChanges();
                //Thêm chi tiết đơn hàng
                foreach (var item in gh)
                {
                    ChiTietDonHang ct = new ChiTietDonHang();
                    ct.MaDH = dh.MaDH;
                    ct.MaSP = item.MaSP;
                    ct.SoLuong = item.Soluong;
                    ct.DonGia = (int)item.Gia;
                    db.ChiTietDonHangs.InsertOnSubmit(ct);

                    // get the objects you want to modify
                    var khos= db.Khos.Where(x => x.MaSP == item.MaSP);

                    foreach (var kho in khos)
                    {
                        // change the properties
                        kho.SoLuong -= item.Soluong;
                    }

                    // EF will pick up those changes and save back to the database.
                }
                db.SubmitChanges();
                Session["Giohang"] = null;
                return RedirectToAction("XacNhanDonHang", "GioHang");
            }
            else
            {
                return View();
            }
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }

        public ActionResult Xemdonhangcanhan()
        {
            TaiKhoan tk = (TaiKhoan)Session["TaiKhoan"];
            if (tk != null)
            {
                List<DonHang> lstdonhang = Laydonhang();
                return RedirectToAction("XemDonHangCaNhan", "GioHang");
                //ViewBag.tongsoluong = tongsoluong();
                //ViewBag.tongtien = tongtien();
                //return View(lstdonhang);
            }
            return View();
        }

        public List<DonHang> Laydonhang()
        {
            List<DonHang> lstdonhang = Session["Donhang"] as List<DonHang>;
            DonHang dh = new DonHang();
            TaiKhoan tk = (TaiKhoan)Session["TaiKhoan"];
            if (lstdonhang != null && tk.UserName == dh.UserName)
            {
                Session["Donhang"] = lstdonhang;
            }
            return lstdonhang;
        }
    }
}
