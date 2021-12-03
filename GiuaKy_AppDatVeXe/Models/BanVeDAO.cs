using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiuaKy_AppDatVeXe.Models
{
    class BanVeDAO
    {
        private DatVeXeKhachEntities db;

        public BanVeDAO()
        {
            db = new DatVeXeKhachEntities();
        }

        public List<LichTrinh> getLichTrinh()
        {
            List<LichTrinh> lichTrinhs = new List<LichTrinh>();
            var query = from lt in db.LichTrinhs select lt;
            foreach (var item in query)
            {
                lichTrinhs.Add(item);
            }
            return lichTrinhs;
        }

        public List<LichTrinh> getLichTrinhbyMaLT(int maLT)
        {
            List<LichTrinh> lichTrinhs = new List<LichTrinh>();
            var query = from lt in db.LichTrinhs where lt.MaLT == maLT select lt;
            foreach (var item in query)
            {
                lichTrinhs.Add(item);
            }
            return lichTrinhs;
        }

        public List<LichTrinh> getLichTrinhByNgayDi(DateTime ngayDi)
        {
            List<LichTrinh> lichTrinhs = new List<LichTrinh>();
            var query = from lt in db.LichTrinhs where lt.NgayDi == ngayDi select lt;
            foreach (var item in query)
            {
                lichTrinhs.Add(item);
            }
            return lichTrinhs;
        }

        public LichTrinh timLichTrinh(string diemDi, string diemDen, string gioDi, DateTime ngayDi)
        {
            var lichTrinh = db.LichTrinhs.Where(lt => lt.DiemDi == diemDi && lt.DiemDen == diemDen && lt.GioDi == gioDi && lt.NgayDi == ngayDi).FirstOrDefault<LichTrinh>();
            if (lichTrinh == null)
                return null;
            return lichTrinh;
        }
    }
}
