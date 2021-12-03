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
        public BanVe()
        {
            InitializeComponent();
            banVeDAO = new BanVeDAO();
            //hienThiDiemDi();
            //hienThiDiemDen();
            //hienThiGioDi();
            DateTime ngayDi = dtpNgayDi.Value;
            LoadLichTrinh(ngayDi);
        }

        public void hienThiDiemDi()
        {
            DateTime ngayDi = dtpNgayDi.Value;
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

        public void hienThiDiemDen()
        {
            DateTime ngayDi = dtpNgayDi.Value;
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

        public void hienThiGioDi()
        {
            DateTime ngayDi = dtpNgayDi.Value;
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
            DateTime ngayDi = dtpNgayDi.Value;
            //hienThiDiemDi();
            //hienThiDiemDen();
            //hienThiGioDi();
            LoadLichTrinh(ngayDi);
            //List<LichTrinh> dsNgayDi = banVeDAO.getLichTrinh(ngayDi);
            //cbDiemDi.DataSource = dsNgayDi;
            //cbDiemDi.DisplayMember = dsNgayDi;

            //cbDiemDen.DataSource = dsNgayDi;
            //cbDiemDen.DisplayMember = dsNgayDi.DiemDen;

            //cbGioDi.DataSource = dsNgayDi;
            //cbGioDi.DisplayMember = dsNgayDi.GioDi;
        }

        private void LoadLichTrinh(DateTime date)
        {
            cbDiemDi.DataSource = banVeDAO.getLichTrinhByNgayDi(date);
            cbDiemDi.DisplayMember = "DiemDi";
        }

        private void cbDiemDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDiemDi.DataSource = null;
            DateTime ngayDi = dtpNgayDi.Value;
            LichTrinh formatLt = cbDiemDi.SelectedItem as LichTrinh;
            cbDiemDi.DataSource = banVeDAO.getLichTrinhbyMaLT(formatLt.MaLT);
            cbDiemDi.DisplayMember = "DiemDi";
        }
    }
}
