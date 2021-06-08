using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;

namespace Dall_Ball
{
    public class NhaCungCap_Dall_Ball
    {
        ShopKidDataContext data = new ShopKidDataContext();
        TuDongTang tt = new TuDongTang();

        public IQueryable loaddataNCC()
        {
            var dsncc = from ds in data.NhaCungCaps
                        select new
                        {
                            ds.MaNCC,
                            ds.TenNCC,
                            ds.DiaChi,
                            ds.SDT,
                        };
            return dsncc;
        }

        public List<NhaCungCapDTO> loadnhacclist()
        {
            List<NhaCungCapDTO> ncc = new List<NhaCungCapDTO>();
            var ds = from k in data.NhaCungCaps
                     select new NhaCungCapDTO
                     {
                         Mancc1=k.MaNCC,
                         Tenncc1=k.TenNCC,
                         Sdt1=k.SDT,
                         Diachi1=k.DiaChi,
                     };
            return ds.ToList();

        }
    
        

        public string getmaNhaCC()
        {
            string x = data.NhaCungCaps.Max(t => t.MaNCC);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));
            if (ma >= 0 && ma < 9)
            {
                return "NC00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "NC0" + (ma + 1).ToString();
            }
            else
                return "";

        }


        public void themNhaCC(string maNCC, string tenNCC, string diachi, string sdt)
        {
            NhaCungCap ncc = new NhaCungCap
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                DiaChi = diachi,
                SDT = sdt,

            };
            data.NhaCungCaps.InsertOnSubmit(ncc);
            data.SubmitChanges();
        }


        public bool sua1NCC(string maNCC, string tenNCC, string diachi, string sdt)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc = data.NhaCungCaps.Where(m => m.MaNCC == maNCC).FirstOrDefault();
            if (ncc!=null)
            {
                ncc.TenNCC = tenNCC;
                ncc.DiaChi = diachi;
                ncc.SDT = sdt;
                data.SubmitChanges();
                return true;
            }
            return false;

        }

        public bool xoa1NCC(string maNCC)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc = data.NhaCungCaps.Where(m => m.MaNCC == maNCC).FirstOrDefault();
            if (ncc != null)
            {
                data.NhaCungCaps.DeleteOnSubmit(ncc);
                data.SubmitChanges();
                return true;
            }
            else
                return false;

        }


        public IQueryable timkiemnhacungcap(string tim)
        {
            var kq = data.NhaCungCaps.Where(c => c.TenNCC.Contains(tim) || c.MaNCC.Contains(tim));
            return kq;

        }

        public List<String> mahdnhaptheonhacc(string mancc)
        {
            var ds = (from vnd in data.PhieuNhaps
                      where vnd.MaNCC == mancc
                      select vnd.MaPN).ToList();
            return ds.ToList();


        }


    }
}
