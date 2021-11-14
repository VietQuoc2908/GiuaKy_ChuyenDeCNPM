using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiuaKy_AppDatVeXe.Models
{
    class KhachHang
    {
        string idKhachHang { get; set; }
        string hoTen { get; set; }
        string sdt { get; set; }

        public KhachHang() { }

        public KhachHang(string idKhachHang, string hoTen, string sdt)
        {
            this.idKhachHang = idKhachHang;
            this.hoTen = hoTen;
            this.sdt = sdt;
        }
    }
}
