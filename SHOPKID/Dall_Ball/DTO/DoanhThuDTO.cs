using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball.DTO
{
   public class DoanhThuDTO
    {

        private string _MahD;
        private long _Tongiaban;
        private DateTime _NgaylapHd;
        private long _Tongianhap;
        private long _DoanhThu;
       
public string MahD { get => _MahD; set => _MahD = value; }
        public long Tongiaban { get => _Tongiaban; set => _Tongiaban = value; }
        public long Tongianhap { get => _Tongianhap; set => _Tongianhap = value; }
        public DateTime NgaylapHd { get => _NgaylapHd; set => _NgaylapHd = value; }
        public long DoanhThu { get => _DoanhThu; set => _DoanhThu = value; }
    }
}
