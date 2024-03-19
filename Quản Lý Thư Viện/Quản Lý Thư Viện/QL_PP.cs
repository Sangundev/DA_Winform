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
    public partial class QL_PP : Form
    {
        public QL_PP()
        {
            InitializeComponent();
        }

        private void Sach_PhieuPhat_Load(object sender, EventArgs e)
        {
            try
            {
                QLTVDB context = new QLTVDB();
                List<PHIEUPHAT> listphat = context.PHIEUPHATs.ToList();

                BindGrid(listphat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<PHIEUPHAT> listtra)
        {
            QLTVDB context = new QLTVDB();

            List<PHIEUPHAT> listphat = context.PHIEUPHATs.ToList();

            dtgpp.Rows.Clear();
            foreach (var item in listtra)
            {
                int index = dtgpp.Rows.Add();
                dtgpp.Rows[index].Cells[0].Value = item.MAPHIEUPHAT;
                dtgpp.Rows[index].Cells[1].Value = item.NGAYLAP;
                dtgpp.Rows[index].Cells[2].Value = item.LYDO;
                dtgpp.Rows[index].Cells[3].Value = item.HINHTHUC;
                dtgpp.Rows[index].Cells[4].Value = item.MAPHIEUMUON;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
