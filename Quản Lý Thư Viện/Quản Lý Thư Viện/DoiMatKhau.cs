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
    public partial class DoiMatKhau : Form
    {
        QLTVDB context = new QLTVDB();
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        bool check()
        {
            if(textEdit1.Text == ""||textEdit2.Text ==""|| textEdit7.Text == "")
            {
                MessageBox.Show("Chua dien du thong tin ");
                return false;
            }
            return true;
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (check())
                {
                    if (textEdit2.Text != textEdit7.Text)
                    {
                        throw new Exception("Xac nhan mat khau khong TRUNG NHAU!");
                    }
                    TAIKHOAN item = context.TAIKHOANs.FirstOrDefault(p => p.MADG == ND_thongtin.MA_DG);
                    if (item != null)
                    {
                        item.MK = textEdit2.Text;
                        context.SaveChanges();
                        MessageBox.Show("Thay doi mk thanh cong!!");
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoiMK_Load(object sender, EventArgs e)
        {
            TAIKHOAN item = context.TAIKHOANs.FirstOrDefault(p => p.MADG == ND_thongtin.MA_DG);

            textEdit1.Text = item.MK;


        }
    }
}
