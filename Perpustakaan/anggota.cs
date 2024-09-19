﻿using System;
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
    public partial class anggota : Form
    {
        //deklarasi
        module mod = new module();
        string id = "0";
        bool aksi = false;

        //awal
        public void awal()
        {
            dataGridView1.DataSource = mod.getData("select * from anggota where nama_anggota like '%" + textBox1.Text + "%' ");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nama";
            dataGridView1.Columns[2].HeaderText = "Alamat";
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
        public anggota()
        {
            InitializeComponent();
        }
        //btn-cancel
        private void button2_Click(object sender, EventArgs e)
        {
            mod.clearForm(groupBox2);
            awal();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //btn-tambah
        private void button3_Click(object sender, EventArgs e)
        {
            mod.clearForm(groupBox2);
            buka();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void anggota_Load(object sender, EventArgs e)
        {
            awal();
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
                if (mod.dialogForm("apakah anda yakin ingin menghapus?"))
                {
                    string sql = "DELETE FROM anggota where idanggota=" + id;
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
                    sql = "INSERT INTO anggota VALUES('" + textBox2.Text + "','" + textBox3.Text + "')";
                    mod.exc(sql);
                    mod.clearForm(groupBox2);
                    awal();
                    MessageBox.Show("data ditambah");
                }
                else
                {
                    sql = "UPDATE anggota SET nama_anggota='" + textBox2.Text + "',alamat='" + textBox3.Text + "' WHERE idanggota="+id;
                    mod.exc(sql);
                    mod.clearForm(groupBox2);
                    awal();
                    MessageBox.Show("data diubah");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
        }
    }
}
