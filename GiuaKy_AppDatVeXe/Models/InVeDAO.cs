using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiuaKy_AppDatVeXe.Models
{
    class InVeDAO
    {
        private DatVeXeKhachEntities db;

        public InVeDAO()
        {
            db = new DatVeXeKhachEntities();
        }

        public DataTable getAll()
        {
            var query = from v in db.Ves select v;
            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã vé";
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã lịch trình";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Mã ghế";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Số điện thoại";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Trạng thái";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Giờ đi";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "Giá vé";
            table.Columns.Add(column);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            foreach (var item in query)
            {
                DataRow row = table.NewRow();
                row["Mã vé"] = item.MaVe;
                row["Mã lịch trình"] = item.MaLT;
                row["Mã ghế"] = item.MaGhe;
                row["Số điện thoại"] = item.Sdt;
                row["Trạng thái"] = item.TrangThai;
                row["Giờ đi"] = item.GioDi;
                row["Giá vé"] = item.GiaVe;
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable find(string txtFind)
        {
            var query = from v in db.Ves where v.MaVe.ToString().Contains(txtFind) || 
                        v.MaLT.ToString().Contains(txtFind) || v.MaGhe.Contains(txtFind) ||
                        v.Sdt.Contains(txtFind) || v.TrangThai.ToString().Contains(txtFind)
                        || v.GioDi.ToString().Contains(txtFind) || v.GiaVe.ToString().Contains(txtFind)
                        select v;
            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã vé";
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã lịch trình";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Mã ghế";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Số điện thoại";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Trạng thái";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Giờ đi";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "Giá vé";
            table.Columns.Add(column);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            foreach (var item in query)
            {
                DataRow row = table.NewRow();
                row["Mã vé"] = item.MaVe;
                row["Mã lịch trình"] = item.MaLT;
                row["Mã ghế"] = item.MaGhe;
                row["Số điện thoại"] = item.Sdt;
                row["Trạng thái"] = item.TrangThai;
                row["Giờ đi"] = item.GioDi;
                row["Giá vé"] = item.GiaVe;
                table.Rows.Add(row);
            }
            return table;
        }

        public int delete(Ve ve)
        {
            var oldVe = db.Ves.FirstOrDefault(v => v.MaVe == ve.MaVe);
            if (oldVe == null)
                return 0;
            db.Ves.Remove(oldVe);
            return db.SaveChanges();
        }

        public int edit(Ve ve)
        {
            var oldVe = db.Ves.FirstOrDefault(v => v.MaVe == ve.MaVe);
            if (oldVe == null)
                return 0;
            oldVe.MaVe = ve.MaVe;
            oldVe.MaLT = ve.MaLT;
            oldVe.MaGhe = ve.MaGhe;
            oldVe.Sdt = ve.Sdt;
            oldVe.TrangThai = ve.TrangThai;
            oldVe.GioDi = ve.GioDi;
            oldVe.GiaVe = ve.GiaVe;
            return db.SaveChanges();
        }

        public Ve getVeBySdtAndMaGhe(string sdt, string maGhe)
        {
            var query = db.Ves.FirstOrDefault(v => v.Sdt == sdt && v.MaGhe == maGhe);
            return query;
        }

        public Boolean compareMaGhe(int maLT, string maGhe)
        {
            var query = from v in db.Ves where (v.MaLT == maLT) select v;
            foreach (var item in query)
            {
                if (maGhe.Equals(item.MaGhe))
                {
                    return false;
                }
            }
            return true;
        }

        public LichTrinh getLichTrinhByMaLT(int maLT)
        {
            var query = db.LichTrinhs.FirstOrDefault(lt => lt.MaLT == maLT);
            return query;
        }
    }
}
