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
    public partial class Pustakawan : Form
    {
        //deklarasi
        module mod = new module();
        string id = "0";
        bool aksi = false;

        //awal
        public void awal()
        {
            dataGridView1.DataSource = mod.getData("select * from pustakawan where nama_pustakawan like '%" + textBox1.Text + "%' ");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nama";
            dataGridView1.Columns[2].HeaderText = "Alamat";
            dataGridView1.Columns[3].HeaderText = "Username";
            dataGridView1.Columns[4].HeaderText = "Password";
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            id = "0";
            aksi = false;

        }
        public void buka()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
        }
        public Pustakawan()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Pustakawan_Load(object sender, EventArgs e)
        {
            awal();
        }
        //button tambah
        private void button3_Click(object sender, EventArgs e)
        {
            mod.clearForm(groupBox2);
            buka();
        }
        //button ubah
        private void button4_Click(object sender, EventArgs e)
        {
             if (id == "0") {
               MessageBox.Show("pilih data dulu");
             }else{
                aksi = true;
                buka();
             }
            
        }
        //tombol hapus
        private void button5_Click(object sender, EventArgs e)
        {
            if (id == "0")
            {
                MessageBox.Show("pilih data dulu");
            }
            else
            {
                if (mod.dialogForm("apakah anda yakin akan menghapus?"))
                {
                    string sql = "delete from pustakawan where idpustakawan =" + id;
                    mod.exc(sql);
                    awal();
                    MessageBox.Show("data dihapus");
                    mod.clearForm(groupBox2);
                }
            }
        }
        //tombol simpan
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
                    sql = "insert into pustakawan values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    mod.exc(sql);
                    mod.clearForm(groupBox2);
                    MessageBox.Show("data ditambah");
                    awal();
                }
                else
                {
                    sql = "update pustakawan set nama_pustakawan='" + textBox2.Text + "',alamat='" + textBox3.Text + "',username='" + textBox4.Text + "',password='" + textBox5.Text + "'";
                    mod.exc(sql);
                    mod.clearForm(groupBox2);
                    MessageBox.Show("data di update");
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
                textBox2.Text =dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            awal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            awal();
            mod.clearForm(groupBox2);
        }
        
    }
}
