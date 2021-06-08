using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball
{
    public class LoaiSanPham_Dall_Ball
    {
        TuDongTang tt = new TuDongTang();
        ShopKidDataContext data = new ShopKidDataContext();

        public List<LoaiSanPham> loaddulieuloaisanpham()
        {
            var dslh = from ds in data.LoaiSanPhams select ds;
            return dslh.ToList();
        }


        public void them1loaisanpham(string maloai, string tenloai)
        {
            LoaiSanPham lsp = new LoaiSanPham();
            lsp.MaLoai = maloai;
            lsp.TenLoai = tenloai;
           
           
            data.LoaiSanPhams.InsertOnSubmit(lsp);
            data.SubmitChanges();
        }

        public bool sua1loaisanpham(string maloai, string tenloai)
        {
            LoaiSanPham lsp = new LoaiSanPham();
            lsp = data.LoaiSanPhams.Where(m => m.MaLoai == maloai).FirstOrDefault();
            if (lsp != null)
            {
                lsp.TenLoai = tenloai;
            
               
                data.SubmitChanges();
                return true;
            }
            else
                return false;
        }

        public void xoasanphamtheoloai(string maloai)
        {
            SanPham sp = new SanPham();
            sp = data.SanPhams.Where(t => t.MaLoai == maloai).FirstOrDefault();
            if (sp!=null)
            {
                data.SanPhams.DeleteOnSubmit(sp);
                data.SubmitChanges();
            }
        }


        public bool xoa1loaisanpham(string maloai)
        {
            LoaiSanPham lsp = new LoaiSanPham();
            lsp = data.LoaiSanPhams.Where(m => m.MaLoai == maloai).FirstOrDefault();
            if (lsp != null)
            {
                data.LoaiSanPhams.DeleteOnSubmit( lsp);
                data.SubmitChanges();
                return true;
            }
            else
                return false;
        }


        public string getmaloaisp(string y)
        {
            string x = data.LoaiSanPhams.Max(t => t.MaLoai);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));
            if (ma >= 0 && ma < 9)
            {
                return "LH00" + (ma + 1).ToString();

            }
            else if (ma >= 9)
            {
                return "LH0" + (ma + 1).ToString();
            }
            else
                return "";
        }

    }
}
