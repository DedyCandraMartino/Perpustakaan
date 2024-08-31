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
        module mod = new module();
        
       
        public Login()
        {
            InitializeComponent();        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //login
        private void button1_Click(object sender, EventArgs e)
        {
            MenuUtama mu = new MenuUtama();
            string sql = "SELECT * FROM pustakawan WHERE username = '" + textBox1.Text + "' AND password='"+textBox2.Text+"'";
            mod.exc(sql);
            if(textBox1.Text=="" || textBox2.Text=="")
            {
                mod.pesan("username atau password belum di isi");
            }
            else
            {
                if (mod.getCount(sql) > 0)
                {
                   
                    mu.Show();
                    object p = mod.getValue(sql, "idpustakawan");
                    mu.idPustakawan = p.ToString();
                    object n = mod.getValue(sql, "nama_pustakawan");
                    mu.pustakawan = n.ToString();
                    this.Hide();
                }
            }

                
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
