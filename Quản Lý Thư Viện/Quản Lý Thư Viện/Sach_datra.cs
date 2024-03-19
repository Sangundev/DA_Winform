using Quản_Lý_Thư_Viện.SQL_DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lý_Thư_Viện
{
    public partial class Sach_datra : Form
    {
        public Sach_datra()
        {
            InitializeComponent();
        }
        QLTVDB context = new QLTVDB();
        private void BindGrid(List<PHIEUMUON> listPhieumuon)
        {
            List<PHIEUTRA> listPT = context.PHIEUTRAs.ToList();
            dtgvsdm.Rows.Clear();
            foreach (var item in listPhieumuon)
            {
                if (listPT.FirstOrDefault(p => p.MAPHIEUMUON == item.MAPHIEUMUON) != null) // != null da tra 
                {
                    int index = dtgvsdm.Rows.Add();
                    dtgvsdm.Rows[index].Cells[0].Value = item.MAPHIEUMUON;
                    dtgvsdm.Rows[index].Cells[1].Value = item.NGAYMUON;
                    dtgvsdm.Rows[index].Cells[2].Value = item.NGAYPHAITRA;
                    dtgvsdm.Rows[index].Cells[3].Value = item.MADG;
                }
            }
        }
        private void Sach_datra_Load(object sender, EventArgs e)
        {
            try
            {

                List<DOCGIA> listdg = context.DOCGIAs.ToList();

                List<PHIEUMUON> listphieumuon = context.PHIEUMUONs.Where(p => p.MADG == ND_thongtin.MA_DG).ToList();
                BindGrid(listphieumuon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
