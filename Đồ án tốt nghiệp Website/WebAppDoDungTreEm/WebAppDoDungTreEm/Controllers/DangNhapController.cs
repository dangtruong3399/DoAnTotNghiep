using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDoDungTreEm.Models;

namespace WebAppDoDungTreEm.Controllers
{
    public class DangNhapController : Controller
    {
        QLTreEmDataContext db = new QLTreEmDataContext();
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult XLDangKy(FormCollection col, TaiKhoan tk)
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
                return View("DangKy");
            }
            db.TaiKhoans.InsertOnSubmit(tk);
            db.SubmitChanges();

            return RedirectToAction("DangNhap");
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XLDangNhap(FormCollection col)
        {
            var username = col["Username"];
            var matkhau = col["matkhau"];
            TaiKhoan x = db.TaiKhoans.FirstOrDefault(t => t.UserName == username);
            if (x == null)
            {
                ViewBag.error = "UserName không tồn tại!!!";
                return View("DangNhap");
            }
            if (x.HoatDong == 0)
            {
                ViewBag.error = "Tài khoản đã bị khóa. Không thể đăng nhập!!!";
                return View("DangNhap");
            }
            if (x.MatKhau != matkhau)
            {
                ViewBag.error = "Mật khẩu không đúng, vui lòng nhập lại!!!";
                return View("DangNhap");
            }
            Session["TaiKhoan"] = x;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
