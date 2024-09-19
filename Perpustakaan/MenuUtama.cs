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
<<<<<<< HEAD
        public string idPustakawan,idBuku,idAnggota;
        module mod = new module();

=======
        public string pustakawan;
        public string idPustakawan ="";
        public string idBuku="";
        module mod = new module();
        Login login = new Login();
        string idAnggota = "0";
>>>>>>> 7f92eb215e310ccc9a1dcdaa5ad2c1d475bcc774
        bool aksi = false;

        //awal
        public void awal()
        {
            dataGridView1.DataSource = mod.getData("select * from anggota where nama_anggota like '%" + textBox1.Text + "%' ");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nama";
            dataGridView1.Columns[2].HeaderText = "Alamat";
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;

            idAnggota = "0";
            idBuku = "0";
            aksi = false;
        }
        //buka
        public void buka()
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
            comboBox1.DataSource = mod.getData("select * from status");
            comboBox1.DisplayMember = "status";
            comboBox1.ValueMember = "idstatus";

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
<<<<<<< HEAD
            CariBuku cariBuku = new CariBuku(this);
           
            cariBuku.Show();
=======
            CariBuku cr = new CariBuku(this);
            cr.ShowDialog();
>>>>>>> 7f92eb215e310ccc9a1dcdaa5ad2c1d475bcc774
            
        }

        private void MenuUtama_Load(object sender, EventArgs e)
        {
            
            awal();
            value();
            comboBox1.SelectedIndex = 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                idAnggota = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (idAnggota == "0")
            {
                mod.pesan("pilih anggota");
            }
            else { 
                buka();
            }
        }

<<<<<<< HEAD
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idBuku=="0"||idAnggota=="0")
            {
                mod.pesan("isi data terlebih dahulu");
            }
            else
            {
                if (mod.dialogForm("Apakah anda yakin ingin menyimpan"))
                {
                    string sql = "INSERT INTO transaksi VALUES ('"+idPustakawan+"','"+idAnggota+"','"+idBuku+"','"+comboBox1.SelectedValue+"','"+dateTimePicker1.Value.ToString("yyyy/MM/dd")+"',NULL)";

                    mod.exc(sql);
                    mod.pesan("Peminjaman berhasil");
                    mod.clearForm(groupBox2);
                    groupBox2.Enabled = false;
                }
            }
=======
        private void button3_Click(object sender, EventArgs e)
        {
            
            mod.pesan(comboBox1.SelectedValue.ToString());
            awal();
            mod.clearForm(groupBox2);
        }
        //simpan
        private void button2_Click(object sender, EventArgs e)
        {
            if (mod.adakosong(groupBox2))
            {
                mod.pesan("isi data terlebih dahulu");
            }else{
                string sql = "INSERT INTO transaksi VALUES ('"+idPustakawan+"','"+idAnggota+"','"+idBuku+"','" +comboBox1.SelectedValue +"','"+dateTimePicker1.Value.ToString("yyyy/MM/dd")+"','')";
                //mod.pesan(idPustakawan);
                //mod.pesan(idAnggota);
                //mod.pesan(idBuku);
                mod.exc(sql);
                mod.clearForm(groupBox2);
                mod.pesan("data berhasil ditambah");
                awal();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            awal();   
>>>>>>> 7f92eb215e310ccc9a1dcdaa5ad2c1d475bcc774
        }

        private void laporanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan lp = new Laporan();
<<<<<<< HEAD
            lp.Show();
=======
            lp.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
>>>>>>> 7f92eb215e310ccc9a1dcdaa5ad2c1d475bcc774
        }
    }
}
