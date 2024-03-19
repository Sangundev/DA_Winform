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
    public partial class QL_PM : Form
    {

        public QL_PM()
        {
            InitializeComponent();
        }
        QLTVDB context = new QLTVDB();
        private void BindGrid(List<PHIEUMUON> listPhieumuon)
        {
            dtgvpm.Rows.Clear();
            foreach (var item in listPhieumuon)
            {
                int index = dtgvpm.Rows.Add();
                dtgvpm.Rows[index].Cells[0].Value = item.MAPHIEUMUON;
                dtgvpm.Rows[index].Cells[1].Value = item.NGAYMUON;
                dtgvpm.Rows[index].Cells[2].Value = item.NGAYPHAITRA;
                dtgvpm.Rows[index].Cells[3].Value = item.MADG;

            

            List<CTPM> listMuon = context.CTPMs.ToList();

                CTPM pm = listMuon.FirstOrDefault(p => p.MAPHIEUMUON == item.MAPHIEUMUON  );
                if (pm != null)
                {
                    dtgvpm.Rows[index].Cells[4].Value = pm.MASACH;
                    dtgvpm.Rows[index].Cells[5].Value = pm.SACH.TENSACH;
                    dtgvpm.Rows[index].Cells[6].Value = pm.SACH.TACGIA;
                }
            }

        }

        private void quanliphieumuon_Load(object sender, EventArgs e)
        {

            try
            {
                QLTVDB context = new QLTVDB();
                List<DOCGIA> listdg = context.DOCGIAs.ToList();
                List<PHIEUMUON> listphieumuon = context.PHIEUMUONs.ToList();
                BindGrid(listphieumuon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvpm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        bool check()
        {
            if(textEdit1.Text == "" || textEdit2.Text == "" || textEdit3.Text == "" || textEdit4.Text == "")
            {
                MessageBox.Show(" vui long dien du thong tin ", " thong bao");
                return false;
            }
            return true;
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DateTime ngaymuon = DateTime.Now;
            QLTVDB context = new QLTVDB();
            List<PHIEUMUON> listStudent = context.PHIEUMUONs.ToList();
            if (check())
            {
                PHIEUMUON s = new PHIEUMUON()
                {
                  MAPHIEUMUON = textEdit1.Text,
                    NGAYMUON = ngaymuon,
                    MADG = textEdit3.Text, 
                    NGAYPHAITRA=dateTimePicker2.Value,
                    
                };

                CTPM a = new CTPM()
                {
                    MAPHIEUMUON = s.MAPHIEUMUON,
                   
                };
                context.PHIEUMUONs.Add(s);
                context.SaveChanges();
               
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("tồn tại");
                //refresh();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
