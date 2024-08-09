using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTNCTest98
{
    public class TaiKhoan
    {
        public int ID { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }

        public TaiKhoan(int _ID, string _TenDangNhap, string _MatKhau)
        {
            ID = _ID;
            TenDangNhap = _TenDangNhap;
            MatKhau = _MatKhau;
        }
    }

}
