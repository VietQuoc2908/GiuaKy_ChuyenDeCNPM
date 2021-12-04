using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiuaKy_AppDatVeXe.Models
{
    class DoanhThuDAO
    {
        DatVeXeKhachEntities db;

        public DoanhThuDAO()
        {
            db = new DatVeXeKhachEntities();
        }

        public DataTable getAll()
        {
            var query = from lt in db.LichTrinhs
                        join v in db.Ves on lt.MaLT equals v.MaLT
                        select new
                        {
                            MaLT = lt.MaLT,
                            NgayDi = lt.NgayDi,
                            MaVe = v.MaVe,
                            MaGhe = v.MaGhe,
                            GiaVe = v.GiaVe
                        };
            //select LichTrinh.MaLT, LichTrinh.NgayDi, Ve.MaVe, Ve.MaGhe, Ve.GiaVe 
            //    from LichTrinh inner join Ve on LichTrinh.MaLT = Ve.MaLT
            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã lịch trình";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Ngày đi";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã vé";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Mã ghế";
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
                row["Mã lịch trình"] = item.MaLT;
                row["Ngày đi"] = item.NgayDi;
                row["Mã vé"] = item.MaVe;
                row["Mã ghế"] = item.MaGhe;
                row["Giá vé"] = item.GiaVe;
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable getVeByNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var query = from lt in db.LichTrinhs
                        join v in db.Ves on lt.MaLT equals v.MaLT
                        where lt.NgayDi >= ngayBatDau && lt.NgayDi <= ngayKetThuc
                        select new
                        {
                            MaLT = lt.MaLT,
                            NgayDi = lt.NgayDi,
                            MaVe = v.MaVe,
                            MaGhe = v.MaGhe,
                            GiaVe = v.GiaVe
                        };
            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã lịch trình";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Ngày đi";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Mã vé";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Mã ghế";
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
                row["Mã lịch trình"] = item.MaLT;
                row["Ngày đi"] = item.NgayDi;
                row["Mã vé"] = item.MaVe;
                row["Mã ghế"] = item.MaGhe;
                row["Giá vé"] = item.GiaVe;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
