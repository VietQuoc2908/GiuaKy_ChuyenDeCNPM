using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiuaKy_AppDatVeXe.Models
{
    class InvoiceVeDAO
    {
        DatVeXeKhachEntities db;

        public InvoiceVeDAO()
        {
            db = new DatVeXeKhachEntities();
        }

        public dynamic getThongTinVe()
        {
            var query = from lt in db.LichTrinhs
                        join v in db.Ves on lt.MaLT equals v.MaLT
                        select new
                        {
                            diemDi = lt.DiemDi,
                            diemDen = lt.DiemDen,
                            ngayDi = lt.NgayDi,
                            gioDi = lt.GioDi,
                            soXe = lt.BienSo,
                            soGhe = v.MaGhe,
                            giaVe = v.GiaVe
                        };
            return query;
        }
    }
}
