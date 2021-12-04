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
    public partial class InVe : UserControl
    {
        private InVeDAO inVeDAO;
        int maLichTrinh;
        int maVe;
        string maGhe;
        string soDienThoai;
        int trangThai;
        string gioDi;
        decimal giaVe;

        public InVe()
        {
            InitializeComponent();
            inVeDAO = new InVeDAO();
        }

        public void showAll()
        {
            DataTable table = inVeDAO.getAll();
            dataGridView1.DataSource = table;
        }

        private void InVe_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnReset.Enabled = false;
            showAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            var index = e.RowIndex;
            if (index >= 0)
            {
                txtSdt.Text = Convert.ToString(dataGridView1.Rows[index].Cells["Số điện thoại"].Value);
                txtSoGhe.Text = Convert.ToString(dataGridView1.Rows[index].Cells["Mã ghế"].Value);
                maLichTrinh = Convert.ToInt32(dataGridView1.Rows[index].Cells["Mã lịch trình"].Value);
                maVe = Convert.ToInt32(dataGridView1.Rows[index].Cells["Mã vé"].Value);
                maGhe = Convert.ToString(dataGridView1.Rows[index].Cells["Mã ghế"].Value);
                soDienThoai = Convert.ToString(dataGridView1.Rows[index].Cells["Số điện thoại"].Value);
                trangThai = Convert.ToInt32(dataGridView1.Rows[index].Cells["Trạng thái"].Value);
                gioDi = Convert.ToString(dataGridView1.Rows[index].Cells["Giờ đi"].Value);
                giaVe = Convert.ToDecimal(dataGridView1.Rows[index].Cells["Giá vé"].Value);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable table = inVeDAO.find(value);
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
                showAll();
            }
            else
            {
                btnTimKiem.Enabled = true;
                btnReset.Enabled = true;
            }

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnReset.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ve veMuonXoa = inVeDAO.getVeBySdtAndMaGhe(txtSdt.Text, txtSoGhe.Text);
                Ve ve = new Ve();
                ve.MaVe = veMuonXoa.MaVe;
                ve.MaLT = veMuonXoa.MaLT;
                ve.MaGhe = veMuonXoa.MaGhe;
                ve.Sdt = veMuonXoa.Sdt;
                ve.TrangThai = veMuonXoa.TrangThai;
                ve.GioDi = veMuonXoa.GioDi;
                ve.GiaVe = veMuonXoa.GiaVe;

                inVeDAO.delete(ve);
                txtSdt.Text = "";
                txtSoGhe.Text = "";
                showAll();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSdt.Clear();
            txtSoGhe.Clear();
            txtTimKiem.Clear();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Ve ve = new Ve();
            ve.MaVe = maVe;
            ve.MaLT = maLichTrinh;
            ve.MaGhe = txtSoGhe.Text;
            ve.Sdt = soDienThoai;
            ve.TrangThai = trangThai;
            ve.GioDi = gioDi;
            ve.GiaVe = giaVe;
            if (inVeDAO.compareMaGhe(ve.MaLT, ve.MaGhe))
            {
                inVeDAO.edit(ve);
                showAll();
            }
            else
                MessageBox.Show("Ghế này đã được đặt. Vui lòng chọn ghế khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
