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
    public partial class MenuUtama : Form
    {
        //deklarasi
        public string idPustakawan;
        public string idBuku;
        module mod = new module();

        string id = "0";
        bool aksi = false;

        //awal
        void awal()
        {
            dataGridView1.DataSource = mod.getData("select * from anggota where nama_anggota like '%" + textBox1.Text + "%' ");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nama";
            dataGridView1.Columns[2].HeaderText = "Alamat";
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;

            id = "";
            idBuku = "";
            aksi = false;
        }
        //buka
        void buka()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled =false;
        }
        public MenuUtama()
        {
            InitializeComponent();
        }
        //value-combobox
        void value()
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        //show-pustakawan
        private void pustakawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pustakawan pustakawan = new Pustakawan();
            pustakawan.Show();
        }
        //show-pustakawan
        private void anggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anggota anggota = new anggota();
            anggota.Show();
        }
        //show-buku
        private void bukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buku buku = new Buku();
            buku.Show();
        }
        //btn-show-cariBuku
        private void button1_Click(object sender, EventArgs e)
        {
            CariBuku cariBuku = new CariBuku();
            cariBuku.Show();
        }

        private void MenuUtama_Load(object sender, EventArgs e)
        {
            awal();
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pengembalianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pengembalian pengembalian = new Pengembalian();
            pengembalian.Show();
        }
    }
}
