﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            column.ColumnName = "Sdt";
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "HoTen";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DiaChi";
            table.Columns.Add(column);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            foreach (var item in query)
            {
                DataRow row = table.NewRow();
                row["Sdt"] = item.Sdt;
                row["HoTen"] = item.HoTen;
                row["DiaChi"] = item.DiaChi;
                table.Rows.Add(row);
            }
            return table;
        }
        
    }
}
