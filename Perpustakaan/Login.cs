using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        module mod = new module();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuUtama mu = new MenuUtama();
            string sql = "SELECT * FROM pustakawan WHERE username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                mod.pesan("username atau password kosong");
            }
            else
            {
                if (mod.getCount(sql) > 0)
                {
                    mod.pesan("Login berhasil");
                    mu.label7.Text = mod.getValue(sql, "nama_pustakawan");
                    mu.idPustakawan = mod.getValue(sql, "idpustakawan");
                    this.Hide();
                    mu.Show();
                }
                else
                {
                    mod.pesan("Password salah");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
