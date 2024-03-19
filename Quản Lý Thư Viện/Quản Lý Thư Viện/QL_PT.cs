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
    public partial class QL_PT : Form
    {
        public QL_PT()
        {
            InitializeComponent();
        }

        private void quanliphieutra_Load(object sender, EventArgs e)
        {
            try
            {
                QLTVDB context = new QLTVDB();
                List<PHIEUTRA> listtra = context.PHIEUTRAs.ToList();
               
                BindGrid(listtra);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<PHIEUTRA> listtra)
        {
            QLTVDB context = new QLTVDB();

            List<PHIEUMUON> listMuon = context.PHIEUMUONs.ToList();

            dtgvtra.Rows.Clear();
            foreach (var item in listtra)
            {
                int index = dtgvtra.Rows.Add();
                dtgvtra.Rows[index].Cells[0].Value = item.MAPHIEUTRA;
                dtgvtra.Rows[index].Cells[5].Value = item.NGAYTRA;
                dtgvtra.Rows[index].Cells[3].Value = item.MASACH;
                dtgvtra.Rows[index].Cells[4].Value = item.MAPHIEUMUON;

                //tim phieu MUON 
                PHIEUMUON pm = listMuon.FirstOrDefault(p=>p.MAPHIEUMUON== item.MAPHIEUMUON);
                if(pm!= null)
                {
                    
                    dtgvtra.Rows[index].Cells[2].Value = pm.NGAYPHAITRA;
                    dtgvtra.Rows[index].Cells[1].Value = pm.MADG;
                }
    
            }
        }

        private void dtgvtra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
