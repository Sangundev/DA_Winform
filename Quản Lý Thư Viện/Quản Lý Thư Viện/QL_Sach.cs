using DevExpress.CodeParser;
using Quản_Lý_Thư_Viện.SQL_DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lý_Thư_Viện
{
    public partial class FromSach : Form
    {
        public FromSach()
        {
            InitializeComponent();
        }

        private void quanlisach_Load(object sender, EventArgs e)
        {
            try
            {
                QLTVDB context = new QLTVDB();
                List<LOAISACH> listls = context.LOAISACHes.ToList();
                List<SACH> listSach = context.SACHes.ToList();
                FillCombobox(listls);
                BindGrid(listSach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
      
        private void Reload()
        {
            List<SACH> listStudent = context.SACHes.ToList();

            BindGrid(listStudent);
            sACHBindingSource.DataSource = context.SACHes.ToList();

        }

        private void FillCombobox(List<LOAISACH> Listsach)
        {
            this.comboBox1.DataSource = Listsach;
            this.comboBox1.DisplayMember = "TENLOAI";
            this.comboBox1.ValueMember = "MALOAI";
        }

        private bool check()
        {
            if (textEdit1.Text.Trim() == "" ||textEdit2.Text.Trim() == "" || textEdit3.Text.Trim() == "" ||textEdit4.Text.Trim()==""|| textEdit5.Text.Trim() == "" || textEdit5.Text.Trim() == "" || textEdit6.Text.Trim() == ""|| textEdit7.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return false;
            }
            return true;

        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            QLTVDB context = new QLTVDB();
            List<SACH> listStudent = context.SACHes.ToList();
            if (check())
            {
                SACH s = new SACH()
                {
                   MASACH = textEdit1.Text,
                   TENSACH=textEdit2.Text,
                   TACGIA=textEdit3.Text,
                   NXB = textEdit4.Text,
                   GIASACH = int.Parse(textEdit5.Text),
                   SOLUONG = int.Parse(textEdit6.Text),
                   TINHTRANG = textEdit7.Text,
                   MALOAI = comboBox1.SelectedValue.ToString()
                };
                context.SACHes.Add(s);
                context.SaveChanges();
                Reload();
                refresh();
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("tồn tại");
                refresh();
            }
        }
        private void refresh()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            textEdit7.Text = "";
            textEdit1.Focus();
        }

        private void dgvqls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                textEdit1.Text = dgvqls.Rows[index].Cells[0].Value.ToString();
                textEdit2.Text = dgvqls.Rows[index].Cells[1].Value.ToString();
                textEdit3.Text = dgvqls.Rows[index].Cells[2].Value.ToString();
                textEdit4.Text = dgvqls.Rows[index].Cells[3].Value.ToString();
                textEdit5.Text = dgvqls.Rows[index].Cells[4].Value.ToString();
                textEdit6.Text = dgvqls.Rows[index].Cells[5].Value.ToString();
                textEdit7.Text = dgvqls.Rows[index].Cells[6].Value.ToString();
                comboBox1.Text = dgvqls.Rows[index].Cells[7].Value.ToString();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var tem = textEdit1.Text;
            SACH dbUpdate = context.SACHes.FirstOrDefault(p => p.MASACH == tem);
            if (dbUpdate != null)
            {
                if (check())
                {
                    dbUpdate.MASACH = textEdit1.Text;
                    dbUpdate.TENSACH = textEdit2.Text;
                    dbUpdate.TACGIA = textEdit3.Text;
                    dbUpdate.NXB = textEdit4.Text;
                    dbUpdate.GIASACH = int.Parse( textEdit5.Text);
                    dbUpdate.SOLUONG =int.Parse( textEdit6.Text);
                    dbUpdate.TINHTRANG = textEdit7.Text;
                    dbUpdate.MALOAI = comboBox1.SelectedValue.ToString();
                    context.SaveChanges();
                    Reload();
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SACH db = context.SACHes.FirstOrDefault(p => p.MASACH == textEdit1.Text);
            if (db != null)
            {
                DialogResult dr = MessageBox.Show("Xóa Sach này?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    context.SACHes.Remove(db);
                    context.SaveChanges();
                    Reload();
                    refresh();
                }
            }
            else
                MessageBox.Show("Không tìm thấy ");
        }
    }
}
