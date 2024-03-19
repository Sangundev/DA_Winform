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
    public partial class Tao_TK : Form
    {
        Login a;
        QLTVDB context = new QLTVDB();
        public Tao_TK(Login a)
        {
            InitializeComponent();
            this.a = a;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit5.Text != textEdit6.Text)
                    throw new Exception("Ma xac nhan mat khau khong dung");
               

                DOCGIA objDocGia = new DOCGIA();
                objDocGia.MADG = textEdit7.Text;
                objDocGia.TENDG = textEdit2.Text;
                if (dateTimePicker1.Value != null)
                    objDocGia.NAMSINH = dateTimePicker1.Value;

                objDocGia.DIACHI = textEdit3.Text;
                objDocGia.GIOITINH = (radioButton1.Checked) ? "Nam" : "Nu";


                context.DOCGIAs.Add(objDocGia);


                TAIKHOAN objTk = new TAIKHOAN();
                objTk.TENDN = textEdit4.Text;
                objTk.MK = textEdit5.Text;
                objTk.MADG = objDocGia.MADG;
                objTk.QUYEN = "User";
                context.TAIKHOANs.Add(objTk);


                context.SaveChanges();

                MessageBox.Show("Luwu du lieu thanh cong!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void Tao_TK_Load(object sender, EventArgs e)
        {
            DOCGIA maxDG = context.DOCGIAs.OrderByDescending(p=>p.MADG).FirstOrDefault();
            if (maxDG != null)
            {

                int sttNext = int.Parse(maxDG.MADG.Replace("DG", "")) + 1;
               
                textEdit7.Text ="DG" + sttNext.ToString("00");
            }
            else

                textEdit7.Text = "DG01";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
