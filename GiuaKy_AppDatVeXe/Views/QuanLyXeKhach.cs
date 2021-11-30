using GiuaKy_AppDatVeXe.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiuaKy_AppDatVeXe
{
    public partial class QuanLyXeKhach : Form
    {
        public QuanLyXeKhach()
        {
            InitializeComponent();
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            this.Text = "Bán Vé";
            pnLoad.Controls.Clear();
            BanVe banVe = new BanVe();
            BanVe banve = banVe;
            banve.Dock = DockStyle.Fill;
            pnLoad.Controls.Add(banve);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            this.Text = "Khách Hàng";
            pnLoad.Controls.Clear();
            KhachHang kh = new KhachHang();
            KhachHang khachHang = kh;
            khachHang.Dock = DockStyle.Fill;
            pnLoad.Controls.Add(khachHang);
        }

        private void btnInVe_Click(object sender, EventArgs e)
        {
            this.Text = "In Vé";
            pnLoad.Controls.Clear();
            InVe ve = new InVe();
            InVe inVe = ve;
            inVe.Dock = DockStyle.Fill;
            pnLoad.Controls.Add(inVe);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            this.Text = "Doanh Thu";
            pnLoad.Controls.Clear();
            DoanhThu dt = new DoanhThu();
            DoanhThu dthu = dt;
            dthu.Dock = DockStyle.Fill;
            pnLoad.Controls.Add(dthu);
        }
    }
}
