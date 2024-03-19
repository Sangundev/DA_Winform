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
    public partial class QL_ND : Form
    {
        public QL_ND()
        {
            InitializeComponent();
        }

        private void quanlynguoidung_Load(object sender, EventArgs e)
        {
            try
            {
                QLTVDB context = new QLTVDB();
                List<DOCGIA> listdg = new List<DOCGIA>();
                List<TAIKHOAN> listtk = context.TAIKHOANs.Where(p => p.QUYEN == "User").ToList();
                BindGrid(listtk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        QLTVDB context = new QLTVDB();
        private void BindGrid(List<TAIKHOAN> listDG)
        {
            QLTVDB context = new QLTVDB();
            List<DOCGIA> listdg = new List<DOCGIA>();
            dataGridView1.Rows.Clear();
            foreach (var item in listDG)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.TENDN;
                dataGridView1.Rows[index].Cells[1].Value = item.MK;
                dataGridView1.Rows[index].Cells[2].Value = item.MADG;


                List<DOCGIA> listMuon = context.DOCGIAs.ToList();

                DOCGIA pm = listMuon.FirstOrDefault(p => p.MADG == item.MADG);
                if (pm != null)
                {
                    dataGridView1.Rows[index].Cells[3].Value = pm.TENDG;

                }
            }
        }
        private void textEdit10_TextChanged(object sender, EventArgs e)
        {
            QLTVDB context = new QLTVDB();
            if (radioButton1.Checked == true)
            {
                var tensach = textEdit10.Text;

                List<TAIKHOAN> listSach = context.TAIKHOANs.Where(p => p.MADG.ToUpper().Contains(tensach.ToUpper())).ToList();

                BindGrid(listSach);
            }
            else if (radioButton3.Checked == true)
            {
               
                var masach = textEdit10.Text;

                List<TAIKHOAN> listSach = context.TAIKHOANs.Where(p => p.TENDN.ToUpper().Contains(masach.ToUpper())).ToList();

                BindGrid(listSach);
            }

        }
    }
}

