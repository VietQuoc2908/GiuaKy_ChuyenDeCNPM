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
    public partial class BanVe : UserControl
    {
        private BanVeDAO banVeDAO;

        Bitmap img1 = Properties.Resources.seat1;
        Bitmap img2 = Properties.Resources.seat2;
        Bitmap img3 = Properties.Resources.seat3;

        private PictureBox p = new PictureBox();

        public BanVe()
        {
            InitializeComponent();
            banVeDAO = new BanVeDAO();
        }

        public void hienThiDiemDi(DateTime ngayDi)
        {
            List<LichTrinh> dsDiemDi = banVeDAO.getLichTrinhByNgayDi(ngayDi);
            for (int i = 0; i < dsDiemDi.Count - 1; i++)
            {
                for (int j = i + 1; j < dsDiemDi.Count; j++)
                {
                    if (dsDiemDi.ElementAt(i).DiemDi.Contains(dsDiemDi.ElementAt(j).DiemDi))
                        dsDiemDi.RemoveAt(j);
                }
            }
            cbDiemDi.DataSource = dsDiemDi;
            cbDiemDi.DisplayMember = "DiemDi";
        }

        public void hienThiDiemDen(DateTime ngayDi)
        {
            List<LichTrinh> dsDiemDen = banVeDAO.getLichTrinhByNgayDi(ngayDi);
            for (int i = 0; i < dsDiemDen.Count - 1; i++)
            {
                for (int j = i + 1; j < dsDiemDen.Count; j++)
                {
                    if (dsDiemDen.ElementAt(i).DiemDen.Contains(dsDiemDen.ElementAt(j).DiemDen))
                        dsDiemDen.RemoveAt(j);
                }
            }
            cbDiemDen.DataSource = dsDiemDen;
            cbDiemDen.DisplayMember = "DiemDen";
        }

        public void hienThiGioDi(DateTime ngayDi)
        {
            List<LichTrinh> dsGioDi = banVeDAO.getLichTrinhByNgayDi(ngayDi);
            for (int i = 0; i < dsGioDi.Count - 1; i++)
            {
                for (int j = i + 1; j < dsGioDi.Count; j++)
                {
                    if (dsGioDi.ElementAt(i).GioDi.Contains(dsGioDi.ElementAt(j).GioDi))
                        dsGioDi.RemoveAt(j);
                }
            }
            cbGioDi.DataSource = dsGioDi;
            cbGioDi.DisplayMember = "GioDi";
        }

        private void dtpNgayDi_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayDi = dtpNgayDi.Value.Date;
            hienThiDiemDi(ngayDi);
            hienThiDiemDen(ngayDi);
            hienThiGioDi(ngayDi);
        }

        private void ChonGhe_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Image = img3;


        }

        private void btnLichTrinh_Click(object sender, EventArgs e)
        {
            string diemDi = cbDiemDi.GetItemText(cbDiemDi.SelectedItem);
            string diemDen = cbDiemDen.GetItemText(cbDiemDen.SelectedItem);
            string gioDi = cbGioDi.GetItemText(cbGioDi.SelectedItem);
            DateTime ngayDi = dtpNgayDi.Value.Date;
            LichTrinh dsLichTrinh = new LichTrinh();
            dsLichTrinh = banVeDAO.timLichTrinh(diemDi, diemDen, gioDi, ngayDi);

            if (dsLichTrinh != null)
            {
                List<Ve> dsVe = banVeDAO.getVebyMaLT(dsLichTrinh.MaLT);
                foreach (Ve ve in dsVe)
                {
                    p.Tag = ve.MaGhe;
                    if (ve.TrangThai == 1)
                    {
                        p.Image = img2;
                    }
                    else
                    {
                        p.Image = img1;
                    }
                }
            }
        }
    }
}
