using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiuaKy_AppDatVeXe.Models
{
    class KhachHangDAO
    {
        private DatVeXeKhachEntities db;

        public KhachHangDAO()
        {
            db = new DatVeXeKhachEntities();
        }

        public DataTable getAll()
        {
            var query = from kh in db.KhachHangs select kh;
            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Số Điện Thoại";
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Họ Tên";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Địa Chỉ";
            table.Columns.Add(column);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            foreach (var item in query)
            {
                DataRow row = table.NewRow();
                row["Số Điện Thoại"] = item.Sdt;
                row["Họ Tên"] = item.HoTen;
                row["Địa Chỉ"] = item.DiaChi;
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable find(string txtFind)
        {
            var query = from kh in db.KhachHangs where kh.Sdt.Contains(txtFind) || kh.HoTen.Contains(txtFind) || kh.DiaChi.Contains(txtFind) select kh;
            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Số Điện Thoại";
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Họ Tên";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Địa Chỉ";
            table.Columns.Add(column);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            foreach (var item in query)
            {
                DataRow row = table.NewRow();
                row["Số Điện Thoại"] = item.Sdt;
                row["Họ Tên"] = item.HoTen;
                row["Địa Chỉ"] = item.DiaChi;
                table.Rows.Add(row);
            }
            return table;
        }

        public int insert(KhachHang khachHang)
        {
            var query = from kh in db.KhachHangs select kh.Sdt;
            foreach (var item in query)
            {
                if (khachHang.Sdt.Equals(item))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
            }
            db.KhachHangs.Add(khachHang);
            return db.SaveChanges();
        }

        public int delete(KhachHang khachHang)
        {
            var oldKhachHang = db.KhachHangs.FirstOrDefault(kh => kh.Sdt == khachHang.Sdt);
            if (oldKhachHang == null)
                return 0;
            db.KhachHangs.Remove(oldKhachHang);
            return db.SaveChanges();
        }

        public int edit(KhachHang khachHang)
        {
            var oldKhachHang = db.KhachHangs.FirstOrDefault(kh => kh.Sdt == khachHang.Sdt);
            if (oldKhachHang == null)
                return 0;
            oldKhachHang.Sdt = khachHang.Sdt;
            oldKhachHang.HoTen = khachHang.HoTen;
            oldKhachHang.DiaChi = khachHang.DiaChi;
            return db.SaveChanges();
        }
        public KhachHang getSdt(string sdt)
        {
            var SDT = db.KhachHangs.FirstOrDefault(kh => kh.Sdt == sdt);
            return SDT;
            //var SDT = db.KhachHangs.Where(lt => lt.Sdt == sdt).FirstOrDefault<KhachHang>();
            //if (SDT == null)
            //    return null;
            //return SDT;
        }
    }
}
