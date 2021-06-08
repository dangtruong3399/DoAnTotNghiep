using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball.DTO
{
   public class TaiKhoanDTO
    {
        private string _UserName;
        private string _TenNV;
        private string _Password;

        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
    }
}
