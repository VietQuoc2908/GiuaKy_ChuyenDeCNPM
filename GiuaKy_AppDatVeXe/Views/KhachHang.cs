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
    public partial class KhachHang : UserControl
    {
        private KhachHangDAO khachHangDAO;

        public KhachHang()
        {
            InitializeComponent();
            khachHangDAO = new KhachHangDAO();
        }

        public void showAll()
        {
            DataTable table = khachHangDAO.getAll();
            dataGridView1.DataSource = table;
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            showAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            var index = e.RowIndex;
            if (index >= 0)
            {
                txtSdt.Text = Convert.ToString(dataGridView1.Rows[index].Cells["Sdt"].Value);
                txtHoTen.Text = Convert.ToString(dataGridView1.Rows[index].Cells["HoTen"].Value);
                txtDiaChi.Text = Convert.ToString(dataGridView1.Rows[index].Cells["DiaChi"].Value);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable table = khachHangDAO.find(value);
                dataGridView1.DataSource = table;
            }
            else
            {
                showAll();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (string.IsNullOrEmpty(value))
            {
                btnTimKiem.Enabled = false;
            }
            else
            {
                btnTimKiem.Enabled = true;
            }
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Models.KhachHang khachHang = new Models.KhachHang();
            khachHang.Sdt = txtSdt.Text;
            khachHang.HoTen = txtHoTen.Text;
            khachHang.DiaChi = txtDiaChi.Text;

            khachHangDAO.insert(khachHang);
            txtSdt.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            showAll();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Models.KhachHang khachHang = new Models.KhachHang();
                khachHang.Sdt = txtSdt.Text;
                khachHang.HoTen = txtHoTen.Text;
                khachHang.DiaChi = txtDiaChi.Text;

                khachHangDAO.delete(khachHang);
                txtSdt.Text = "";
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
                showAll();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Models.KhachHang khachHang = new Models.KhachHang();
            khachHang.Sdt = txtSdt.Text;
            khachHang.HoTen = txtHoTen.Text;
            khachHang.DiaChi = txtDiaChi.Text;

            khachHangDAO.edit(khachHang);
            txtSdt.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            showAll();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
