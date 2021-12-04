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

        public List<Ve> getVebyMaLT(int maLT)
        {
            List<Ve> ves = new List<Ve>();
            var query = from v in db.Ves where v.MaLT == maLT select v;
            foreach (var item in query)
            {
                ves.Add(item);
            }
            return ves;
        }
        public Ve getVeByMaLT(int maLT)
        {
            var ve = db.Ves.Where(lt => lt.MaLT == maLT).FirstOrDefault<Ve>(); 
            if (ve == null)
                return null;
            return ve;
        }
        public int insert(Ve ve)
        {
            db.Ves.Add(ve);
            return db.SaveChanges();
        }
    }
}
