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
    public partial class ND_thongtin : Form
    {
        public static string MA_DG = "";
        public ND_thongtin()
        {
            InitializeComponent();
        }

        private void nguoidung_thongtin_Load(object sender, EventArgs e)
        {
            QLTVDB context = new QLTVDB();
            SetDocGia(context.DOCGIAs.FirstOrDefault(p => p.MADG == MA_DG));
        }
        void SetDocGia(DOCGIA item)
        {
            if (item != null)
            {
                textBox1.Text = item.TENDG;
                textBox5.Text = item.DIACHI;
                radioButton1.Checked = (item.GIOITINH == "Nam") ? true : false;
                dateTimePicker1.Value = item.NAMSINH.Value;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //luu 
            QLTVDB context = new QLTVDB();
            DOCGIA item = context.DOCGIAs.FirstOrDefault(p => p.MADG == MA_DG); 
            if(item != null)
            {
                item.TENDG = textBox1.Text;
                item.DIACHI = textBox5.Text;
                item.NAMSINH = dateTimePicker1.Value;
                item.GIOITINH = (radioButton1.Checked ? "Nam" : "Nu");
                context.SaveChanges();
                MessageBox.Show("Luu thanh cong!!", "Luwu", MessageBoxButtons.OK);
            }


        }
    }
}
