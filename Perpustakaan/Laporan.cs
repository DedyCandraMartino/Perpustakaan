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
    public partial class Laporan : Form
    {
        public Laporan()
        {
            InitializeComponent();
        }
        module mod = new module();
        public void awal()
        {
            string sql = "SELECT idpeminjaman,nama_pustakawan,nama_anggota,alamat_anggota,judul,penerbit,tanggal_peminjaman,tanggal_pengembalian,status FROM Vtransaksi WHERE nama_anggota LIKE '%" + textBox2.Text + "%' and tanggal_peminjaman='"+dateTimePicker1.Value.ToString("yyyy/MM/dd")+"' ORDER BY tanggal_peminjaman ASC";

            dataGridView1.DataSource = mod.getData(sql);
            
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Pustakawan";
            dataGridView1.Columns[2].HeaderText = "Anggota";
            dataGridView1.Columns[3].HeaderText = "Alamat anggota";
            dataGridView1.Columns[4].HeaderText = "judul";
            dataGridView1.Columns[5].HeaderText = "Tanggal pinjam";
            dataGridView1.Columns[6].HeaderText = "Tanggal kembali";
            dataGridView1.Columns[7].HeaderText = "Status";
            
        }
        private void Laporan_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            awal();
        }
    }
}
