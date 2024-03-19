using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraPrinting.Native;
using Quản_Lý_Thư_Viện.SQL_DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lý_Thư_Viện
{
    public partial class ND_timkiemsach : Form
    {
        public ND_timkiemsach()
        {
            InitializeComponent();
        }

        private void BindGrid(List<SACH> listbook)
        {
            dgvqls.Rows.Clear();
            foreach (var item in listbook)
            {
                int index = dgvqls.Rows.Add();
                dgvqls.Rows[index].Cells[0].Value = item.MASACH;
                dgvqls.Rows[index].Cells[1].Value = item.TENSACH;
                dgvqls.Rows[index].Cells[2].Value = item.TACGIA;
                dgvqls.Rows[index].Cells[3].Value = item.NXB;
                dgvqls.Rows[index].Cells[4].Value = item.GIASACH;
                dgvqls.Rows[index].Cells[5].Value = item.SOLUONG;
                dgvqls.Rows[index].Cells[6].Value = item.TINHTRANG;
                dgvqls.Rows[index].Cells[7].Value = item.MALOAI;


            }
        }
        QLTVDB context = new QLTVDB();
        private void ND_timkiemsach_Load(object sender, EventArgs e)
        {
            try
            {
                QLTVDB context = new QLTVDB();
                List<LOAISACH> lisloaiSach = context.LOAISACHes.ToList();
                List<SACH> listSach = context.SACHes.ToList();
                List<PHIEUMUON> listMuon = context.PHIEUMUONs.ToList();
                BindGrid(listSach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textEdit10_TextChanged(object sender, EventArgs e)
        {
            var tensach = textEdit10.Text;

            List<SACH> listSach = context.SACHes.Where(p => p.TENSACH.ToUpper().Contains(tensach.ToUpper())).ToList();

            BindGrid(listSach);
        }

        private void ND_timkiemsach_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEdit10_TextChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                var tensach = textEdit10.Text;

                List<SACH> listSach = context.SACHes.Where(p => p.TENSACH.ToUpper().Contains(tensach.ToUpper())).ToList();

                BindGrid(listSach);
            }
            else if(radioButton1.Checked == true)
            {
                var masach = textEdit10.Text;

                List<SACH> listSach = context.SACHes.Where(p => p.MASACH.ToUpper().Contains(masach.ToUpper())).ToList();

                BindGrid(listSach);
            }
            else if (radioButton3.Checked == true)
            {
                var tg = textEdit10.Text;

                List<SACH> listSach = context.SACHes.Where(p => p.TACGIA.ToUpper().Contains(tg.ToUpper())).ToList();

                BindGrid(listSach);
            }
            else if (radioButton4.Checked == true)
            {
                var tt = textEdit10.Text;

                List<SACH> listSach = context.SACHes.Where(p => p.TINHTRANG.ToUpper().Contains(tt.ToUpper())).ToList();

                BindGrid(listSach);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvqls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvqls.Rows[e.RowIndex];
            textEdit1.Text = Convert.ToString(row.Cells["Column1"].Value);
            textEdit2.Text = Convert.ToString(row.Cells["Column2"].Value);
        }

        public static string MA_PM = "";
        private void btnMuon_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //DOCGIA item = context.DOCGIAs.FirstOrDefault(p => p.MADG == MA_DG);
            //DateTime NgayMuon = DateTime.Now;
            //TimeSpan plus = new System.TimeSpan(1, 0, 0);
            //DateTime NgayHenTra = NgayMuon.Add(plus);
            //if (item != null)
            //{
            //    PHIEUMUON maxPM = context.PHIEUMUONs.OrderByDescending(p => p.MAPHIEUMUON).FirstOrDefault();
            //    PHIEUMUON itemMuon = new PHIEUMUON();
            //    itemMuon.MADG = item.MADG;
            //    int sttNext = int.Parse(maxPM.MADG.Replace("PM", "")) + 1;
            //    itemMuon.MAPHIEUMUON = "PM" + sttNext.ToString("00");
            //    itemMuon.NGAYMUON = NgayMuon;
            //    itemMuon.NGAYPHAITRA = NgayHenTra;
            //    context.PHIEUMUONs.Add(itemMuon);
            //    context.SaveChanges();
            //    context.PHIEUMUONs.ToList();
            //    MessageBox.Show("Muon thanh cong", "Thong Bao");
            //}

            DateTime NgayMuon = DateTime.Now;

            PHIEUMUON a = new PHIEUMUON();

            PHIEUMUON maxDG = context.PHIEUMUONs.OrderByDescending(p => p.MAPHIEUMUON).FirstOrDefault();
             int sttNext= int.Parse(maxDG.MAPHIEUMUON.Replace("PM", "")) + 1;
            a.MAPHIEUMUON = "PM" + sttNext.ToString("00");
            a.NGAYMUON = NgayMuon;
                 if (dateTimePicker2.Value != null)
                    a.NGAYPHAITRA = dateTimePicker2.Value;

            context.PHIEUMUONs.Add(a);
            //context.SaveChanges();

            CTPM b = new CTPM();
                b.MASACH = textEdit1.Text;
                b.MAPHIEUMUON = a.MAPHIEUMUON;
            context.CTPMs.Add(b);
            context.SaveChanges();
            MessageBox.Show("Luwu du lieu thanh cong!!");

        }
    }
}
