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
    public partial class Status : Form
    {
        //deklarasi
        module mod = new module();
        bool aksi = false;
        string id = "0";
        
        //awal
        public void awal()
        {
            dataGridView1.DataSource = mod.getData("select * from status where status like '%" + textBox1.Text + "%' ");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "status";
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            id = "0";
            aksi = false;
        }
        //buka
        public void buka()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;

        }
        public Status()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Status_Load(object sender, EventArgs e)
        {
            awal();
        }
        //btn-tambah
        private void button3_Click(object sender, EventArgs e)
        {
            mod.clearForm(groupBox2);
            buka();
        }
        //btn-ubah
        private void button4_Click(object sender, EventArgs e)
        {
            if (id == "0")
            {
                MessageBox.Show("pilih data dulu");
            }
            else
            {
                aksi = true;
                buka();
            }
        }
        //btn-hapus
        private void button5_Click(object sender, EventArgs e)
        {
            if (id == "0")
            {
                MessageBox.Show("pilih data dulu");
            }
            else
            {
                if (mod.dialogForm("apakah anda yakin akan menghapus "))
                {
                    string sql = "DELETE FROM pustakawan WHERE idstatus=" + id;
                    mod.exc(sql);
                    awal();
                    MessageBox.Show("data dihapus");
                    mod.clearForm(groupBox2);
                }
            }
        }
        //btn-simpan
        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (mod.adakosong(groupBox2))
            {
                MessageBox.Show("isi data terlebih dahulu!");
            }
            else
            {
                if (!aksi)
                {
                    sql = "INSERT INTO status VALUES('" + textBox2.Text + "')";
                    mod.exc(sql);
                    mod.clearForm(groupBox2);
                    MessageBox.Show("data ditambah");
                    awal();
                }
                else
                {
                    sql = "UPDATE status SET status='" + textBox2.Text + "'";
                    mod.exc(sql);
                    mod.clearForm(groupBox2);
                    MessageBox.Show("data diubah");
                    awal();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }
        //btn-batal
        private void button2_Click(object sender, EventArgs e)
        {
            awal();
            mod.clearForm(groupBox2);
        }
    }
}
