using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDoDungTreEm.Models;

namespace WebAppDoDungTreEm.Controllers
{
    public class AdminController : Controller
    {
        QLTreEmDataContext db = new QLTreEmDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            List<SanPham> list = db.SanPhams.ToList();
            return View(list);
        }
        public ActionResult TaiKhoan()
        {
            List<TaiKhoan> list = db.TaiKhoans.ToList();
            return View(list);
        }

        public ActionResult DonHang()
        {
            List<DonHang> list = db.DonHangs.ToList();
            return View(list);
        }
        public ActionResult LoaiSP()
        {
            List<LoaiSanPham> list = db.LoaiSanPhams.ToList();
            return View(list);
        }
        public ActionResult ChiTietDonHang(int madh)
        {
            List<ChiTietDonHang> list = db.ChiTietDonHangs.Where(t => t.MaDH == madh).ToList();
            return View(list);
        }
        public ActionResult ThemTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XLThemTaiKhoan(FormCollection col, TaiKhoan tk)
        {
            tk.UserName = col["Username"];
            tk.MatKhau = col["matkhau"];
            tk.HoTen = col["hoten"];
            tk.DiaChi = col["diachi"];
            tk.SoDienThoai = col["sodt"];
            tk.HoatDong = 1;
            tk.PhanQuyen = 0;
            TaiKhoan x = db.TaiKhoans.FirstOrDefault(t => t.UserName == tk.UserName);
            if (x != null)
            {
                ViewBag.error = "UserName đã tồn tại, vui lòng nhập tên khác!!";
                return View("ThemTaiKhoan");
            }

            db.TaiKhoans.InsertOnSubmit(tk);
            db.SubmitChanges();

            return RedirectToAction("Taikhoan");
        }
        public ActionResult SuaTaiKhoan(string usr)
        {
            TaiKhoan tk = db.TaiKhoans.FirstOrDefault(t => t.UserName == usr);
            return View(tk);
        }
        [HttpPost]
        public ActionResult XLSuaTaiKhoan(TaiKhoan tk)
        {
            TaiKhoan obj = db.TaiKhoans.FirstOrDefault(t => t.UserName == tk.UserName);
            obj.HoTen = tk.HoTen;
            obj.DiaChi = tk.DiaChi;
            obj.SoDienThoai = tk.SoDienThoai;
            obj.PhanQuyen = tk.PhanQuyen;

            UpdateModel(obj);
            db.SubmitChanges();
            return RedirectToAction("TaiKhoan", "Admin");
        }

        public ActionResult XoaTaiKhoan(string usr)
        {
            TaiKhoan tk = db.TaiKhoans.FirstOrDefault(t => t.UserName == usr);
            db.TaiKhoans.DeleteOnSubmit(tk);
            db.SubmitChanges();
            return RedirectToAction("TaiKhoan", "Admin");
        }
        public ActionResult ThemSanPham()
        {
            ViewBag.Loais = db.LoaiSanPhams.ToList();
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult XLThemSanPham(SanPham sp, HttpPostedFileBase fileupload)
        {
            //here
            ViewBag.Loais = new SelectList(db.LoaiSanPhams.ToList(), "Maloai", "TenLoai");

            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            else
            {
                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/SanPham/"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                sp.MaSP = getmasptutang();
                sp.HinhAnh = fileName;

                //sp.MaLoai = 1;
                //
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return RedirectToAction("Index", "Admin");
            }
        }
        public string getmasptutang()
        {

            using (QLTreEmDataContext db = new QLTreEmDataContext())
            {
                if (db.SanPhams.ToList().Count <= 0)
                {
                    return "SP001";
                }
                string x = db.SanPhams.Max(t => t.MaSP);
                int ma = int.Parse(x.Substring(x.Length - 3, 3));
                if (ma >= 0 && ma < 9)
                {
                    return "SP00" + (ma + 1).ToString();
                }
                else if (ma >= 9 && ma < 99)
                {
                    return "SP0" + (ma + 1).ToString();
                }
                else if (ma >= 99 && ma <= 999)
                    return "SP";
                else return "";
            }
        }

        public ActionResult XoaSanPham(string msp)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(t => t.MaSP == msp);
            Kho kh = db.Khos.FirstOrDefault(t => t.MaSP == msp);
            if (sp != null)
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.Khos.DeleteOnSubmit(kh);
                db.SubmitChanges();
            }
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult SuaSanPham(string msp)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(t => t.MaSP == msp);
            ViewBag.Loais = new SelectList(db.LoaiSanPhams.ToList(), "MaLoai", "TenLoai", sp.MaLoai);
            return View(sp);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult XLSuaSanPham(SanPham sp, HttpPostedFileBase fileupload)
        {
            ViewBag.Loais = new SelectList(db.LoaiSanPhams.ToList(), "MaLoai", "TenLoai", sp.MaLoai);
            //lay sp can sua ra
            var sanpham = db.SanPhams.SingleOrDefault(p => p.MaSP == sp.MaSP);
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            else
            {

                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/SanPham/"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                sanpham.HinhAnh = fileName;
                sanpham.DonViTinh = sp.DonViTinh;
                sanpham.TenSP = sp.TenSP;
                sanpham.GiaNhap = sp.GiaNhap;
                sanpham.GiaBan = sp.GiaBan;
                //UpdateModel(sp);
                db.SubmitChanges();
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult SuaDonHang(int donhang)
        {
            DonHang dh = db.DonHangs.FirstOrDefault(t => t.MaDH == donhang);
            return View(dh);
        }
        [HttpPost]
        public ActionResult XLSuaDonHang(DonHang dh)
        {
            var donHang = db.DonHangs.SingleOrDefault(t => t.MaDH == dh.MaDH);
            donHang.DaThanhToan = dh.DaThanhToan;
            donHang.TinhTrangGiaoHang = dh.TinhTrangGiaoHang;
            db.SubmitChanges();
            return RedirectToAction("DonHang", "Admin");
        }
        public ActionResult XoaDonHang(int dh)
        {
            ChiTietDonHang ctdh = db.ChiTietDonHangs.FirstOrDefault(t => t.MaDH == dh);
            DonHang dhang = db.DonHangs.FirstOrDefault(t => t.MaDH == dh);
            TempData["message2"] = "";
            if (dhang.TinhTrangGiaoHang == 0)
            {
                db.ChiTietDonHangs.DeleteOnSubmit(ctdh);
                db.DonHangs.DeleteOnSubmit(dhang);
            }
            else
            {
                TempData["message2"] = "Không xóa được đơn hàng đã giao!";
            }
            db.SubmitChanges();
            return RedirectToAction("DonHang", "Admin");
        }
        //Thong ke
        public ActionResult ThongKe()
        {

            List<ThongKe> list = (List<ThongKe>)TempData["list"];
            if (list == null) list = new List<ThongKe>();
            return View(list);
        }
        [HttpPost]
        public ActionResult XLThongKe(FormCollection collection)
        {


            TempData["list"] = new List<ThongKe>();
            List<ThongKe> list = new List<ThongKe>();
            string nam = collection["nam"].Trim();
            string thang = collection["thang"].Trim();

            if (thang != "" && nam == "")
            {

                var tempList = from dh in db.DonHangs
                               join ctdh in db.ChiTietDonHangs on dh.MaDH equals ctdh.MaDH
                               where dh.NgayGiao.Value.Month == Int32.Parse(thang)
                               select new ThongKe
                               {
                                   MaDH = dh.MaDH,
                                   MaSP = ctdh.MaSP,
                                   DonGia = (double)ctdh.DonGia,
                                   NgayDatHang = (DateTime)dh.NgayDatHang,
                                   NgayGiao = (DateTime)dh.NgayGiao,
                                   Soluong = (int)ctdh.SoLuong
                               };
                list = tempList.ToList();

            }
            else if (nam != "" && thang == "")
            {
                var tempList = from dh in db.DonHangs
                               join ctdh in db.ChiTietDonHangs on dh.MaDH equals ctdh.MaDH
                               where dh.NgayGiao.Value.Year == Int32.Parse(nam)
                               select new ThongKe
                               {
                                   MaDH = dh.MaDH,
                                   MaSP = ctdh.MaSP,
                                   DonGia = (double)ctdh.DonGia,
                                   NgayDatHang = (DateTime)dh.NgayDatHang,
                                   NgayGiao = (DateTime)dh.NgayGiao,
                                   Soluong = (int)ctdh.SoLuong
                               };
                list = tempList.ToList();

            }
            else if (nam == "" && thang == "")
            {


            }
            else
            {
                var tempList = from dh in db.DonHangs
                               join ctdh in db.ChiTietDonHangs on dh.MaDH equals ctdh.MaDH
                               where dh.NgayGiao.Value.Month == Int32.Parse(thang)
                               && dh.NgayGiao.Value.Year == Int32.Parse(nam)
                               select new ThongKe
                               {
                                   MaDH = dh.MaDH,
                                   MaSP = ctdh.MaSP,
                                   DonGia = (double)ctdh.DonGia,
                                   NgayDatHang = (DateTime)dh.NgayDatHang,
                                   NgayGiao = (DateTime)dh.NgayGiao,
                                   Soluong = (int)ctdh.SoLuong
                               };

                list = tempList.ToList();
            }

            TempData["list"] = list;
            return RedirectToAction("ThongKe", "Admin");
        }
    }
}
