﻿using GiuaKy_AppDatVeXe.Models;
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
        //private PictureBox p = new PictureBox();

        public BanVe()
        {
            InitializeComponent();
            banVeDAO = new BanVeDAO();
            btnLichTrinh.Enabled = false;
            panelSoDoGhe.Enabled = false;
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
            btnLichTrinh.Enabled = true;


        }
        public ListBox lboxSoGheChon = new ListBox();
        private void ChonGhe_Click(object sender, EventArgs e)
        {
            
            PictureBox p = (PictureBox)sender;
            if(p.Image == img3) 
            {
                p.Image = img1;
                lboxSoGheChon.Items.Remove(p.Name);
                hienThiThongTinVe();
            }
            else
            {
                p.Image = img3;
                lboxSoGheChon.Items.Add(p.Name);
                hienThiThongTinVe();
            }
           
        }

        public void loadLichTrinh()
        {
            string diemDi = cbDiemDi.GetItemText(cbDiemDi.SelectedItem);
            string diemDen = cbDiemDen.GetItemText(cbDiemDen.SelectedItem);
            string gioDi = cbGioDi.GetItemText(cbGioDi.SelectedItem);
            DateTime ngayDi = dtpNgayDi.Value.Date;
            LichTrinh dsLichTrinh = new LichTrinh();
            dsLichTrinh = banVeDAO.timLichTrinh(diemDi, diemDen, gioDi, ngayDi);

            if (dsLichTrinh != null)
            {
                List<PictureBox> pictureBoxes = danhsachPictureBox();
                List<Ve> dsVe = banVeDAO.getVebyMaLT(dsLichTrinh.MaLT);
                foreach (Ve ve in dsVe)
                {
                    if (ve.TrangThai == 1)
                    {
                        foreach (var item in pictureBoxes)
                        {
                            if (item.Name == ve.MaGhe)
                            {
                                item.Image = img2;
                                item.Enabled = false;

                            }
                        }
                    }
                    else
                    {
                        foreach (var item in pictureBoxes)
                        {
                            item.Image = img1;
                        }
                    }
                }
                panelSoDoGhe.Enabled = true;
            }
            else
            {
                MessageBox.Show("Không có chuyến này! Bạn vui lòng tìm chuyến khác nhé", "Lịch trình không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                panelSoDoGhe.Enabled = false;
            }
        }
        //Hien thi thong tin ve
        private void hienThiThongTinVe()
        {
            string chuyen = cbDiemDi.Text + '-' + cbDiemDen.Text;
            string thoigian = dtpNgayDi.Text + ' ' + cbGioDi.Text;
            int count = 0;
            string ghe = "";
            string diemDi = cbDiemDi.GetItemText(cbDiemDi.SelectedItem);
            string diemDen = cbDiemDen.GetItemText(cbDiemDen.SelectedItem);
            string gioDi = cbGioDi.GetItemText(cbGioDi.SelectedItem);
            DateTime ngayDi = dtpNgayDi.Value.Date;
            LichTrinh dsLichTrinh =  banVeDAO.timLichTrinh(diemDi, diemDen, gioDi, ngayDi);
            //Ve ves = banVeDAO.getVeByMaLT(dsLichTrinh.MaLT);
            foreach (var item in lboxSoGheChon.Items)
            {
                ghe += item.ToString() + " ";
                count++;

            }
            lbSoGhe.Text = ghe;
            lbChuyen.Text = chuyen;
            lbThoiGian.Text = thoigian;
            lbSoLuong.Text = count.ToString();
            lbGiaVe.Text = dsLichTrinh.GiaTien.ToString();
            lbTongTien.Text = (count * dsLichTrinh.GiaTien).ToString();
        }
        //Lấy thông tin Picturebox
        private List<PictureBox> danhsachPictureBox()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            Control[] matches;
            for (int i = 1; i <= 30; i++)
            {
                matches = this.Controls.Find("A" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is PictureBox)
                {
                    pictureBoxes.Add((PictureBox)matches[0]);
                }
            }
            return pictureBoxes;
        }
        private void btnLichTrinh_Click(object sender, EventArgs e)
        {
            loadLichTrinh();
        }

        private void cbGioDi_TextChanged(object sender, EventArgs e)
        {
            btnLichTrinh.Enabled = true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diemDi = cbDiemDi.GetItemText(cbDiemDi.SelectedItem);
            string diemDen = cbDiemDen.GetItemText(cbDiemDen.SelectedItem);
            string gioDi = cbGioDi.GetItemText(cbGioDi.SelectedItem);
            DateTime ngayDi = dtpNgayDi.Value.Date;
            LichTrinh dsLichTrinh = banVeDAO.timLichTrinh(diemDi, diemDen, gioDi, ngayDi);
            int maLT = dsLichTrinh.MaLT;
            int trangThai = 1;
            Decimal giaVe = dsLichTrinh.GiaTien;

            foreach (string item in lboxSoGheChon.Items)
            {
                Ve ve = new Ve();
                ve.MaLT = maLT;
                ve.MaGhe = item;
                ve.Sdt = sdt;
                ve.TrangThai = trangThai;
                ve.GioDi = gioDi;
                ve.GiaVe = giaVe;
                banVeDAO.insert(ve);
            }
            loadLichTrinh();
        }
    }
}
