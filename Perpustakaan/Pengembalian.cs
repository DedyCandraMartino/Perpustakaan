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
    public partial class Pengembalian : Form
    {
        //deklarasi
        module mod = new module();
        
        public void awal()
        {
            
            dataGridView1.DataSource = mod.getData("SELECT idpeminjaman,nama_pustakawan,nama_anggota,judul,tanggal_peminjaman,status FROM Vtransaksi WHERE nama_anggota LIKE '%"+textBox4.Text+"%' AND idstatus ='"+comboBox2.SelectedValue+"'");
            //dataGridView1.Columns[0].HeaderText = "ID";
            //dataGridView1.Columns[1].HeaderText = "Pustakawan";
            //dataGridView1.Columns[2].HeaderText = "Anggota";
            //dataGridView1.Columns[3].HeaderText = "Judul";
            //dataGridView1.Columns[4].HeaderText = "Tanggal Pinjam";
            //dataGridView1.Columns[5].HeaderText = "Status";
        }
        void getcombo1()
        {
            comboBox1.DataSource = mod.getData("SELECT * FROM status");
            comboBox1.DisplayMember = "status";
            comboBox1.ValueMember = "idstatus";

        }
        void getcombo2()
        {
            comboBox2.DataSource = mod.getData("SELECT * FROM status");
            comboBox2.DisplayMember = "status";
            comboBox2.ValueMember = "idstatus";

        }
        public Pengembalian()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Pengembalian_Load(object sender, EventArgs e)
        {
            getcombo1();
            getcombo2();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            awal();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
