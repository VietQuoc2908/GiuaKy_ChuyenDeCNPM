using GiuaKy_AppDatVeXe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiuaKy_AppDatVeXe.Views
{
    public partial class DoanhThu : UserControl
    {
        private DoanhThuDAO doanhThuDAO;
        
        public DoanhThu()
        {
            InitializeComponent();
            doanhThuDAO = new DoanhThuDAO();
        }

        public void showAll()
        {
            DataTable table = doanhThuDAO.getAll();
            dataGridView1.DataSource = table;
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            showAll();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;

            DataTable table = doanhThuDAO.getVeByNgay(ngayBatDau, ngayKetThuc);
            dataGridView1.DataSource = table;
            txtDoanhThu.Text = string.Format("{0:0,0} VNĐ", tinhTongDoanhThu());
        }

        private decimal tinhTongDoanhThu()
        {
            decimal sum = 0;
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                sum += Convert.ToDecimal(dataGridViewRow.Cells["Giá vé"].Value);
            }
            return sum;
        }
    }
}
