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
    }
}
