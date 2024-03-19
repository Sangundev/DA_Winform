using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Thư_Viện.SQL_DL;
using System.Data.SqlClient;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraRichEdit.Fields;

namespace Quản_Lý_Thư_Viện
{
    public partial class Login : Form
    {
        public bool isExit = true;
        QLTVDB qLTVDB = new QLTVDB(); 
        public Login()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isExit)
                if (MessageBox.Show("Ban co muon thoat chuong trinh ", " canh bao ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tao_TK a = new Tao_TK(this);
            a.ShowDialog();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Quen_MK a = new Quen_MK();
            a.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtmk.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (isExit)
                if (MessageBox.Show("Ban co muon thoat chuong trinh ", " canh bao ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<TAIKHOAN> list = qLTVDB.TAIKHOANs.ToList();
            var firstLogin = list.FirstOrDefault(item => item.TENDN.Equals(txttentk.Text) && item.MK == txtmk.Text);

            if (firstLogin != null)
            {
                MessageBox.Show("Dang nhap thanh cong");
                ND_thongtin.MA_DG = firstLogin.MADG;
                new FormMain(this, firstLogin.QUYEN == "Admin").Show();
                txtmk.Text = "";
                this.Hide();
            }

            else
            {
                if (list.FirstOrDefault(item => item.TENDN.Equals(txttentk.Text)) != null)
                {
                    MessageBox.Show("Mat khau khong dung!");
                    ND_thongtin.MA_DG = txtmk.Text = "";
                    txtmk.Focus();

                }
                else
                {
                    MessageBox.Show("Khong ton tai tai khoan!");
                    ND_thongtin.MA_DG = txttentk.Text = txtmk.Text = "";
                    txttentk.Focus();
                }
            }
        }
    }
}