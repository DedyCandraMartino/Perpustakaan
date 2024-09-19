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
    public partial class Pengembalian : Form
    {
        module mod = new module();
        string id = "0";
        public Pengembalian()
        {
            InitializeComponent();
        }
        string idStatus = "0";
        public void awal()
        {
            string sql = "SELECT idpeminjaman,nama_pustakawan,nama_anggota,judul,tanggal_peminjaman,status FROM Vtransaksi WHERE nama_anggota LIKE '%" + textBox4.Text + "%'and idstatus=2";
            dataGridView1.DataSource = mod.getData(sql);
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Pustakawan";
            dataGridView1.Columns[2].HeaderText = "Anggota";
            dataGridView1.Columns[3].HeaderText = "Judul";
            dataGridView1.Columns[4].HeaderText = "Tanggal pinjam";
            dataGridView1.Columns[5].HeaderText = "status";
            comboBox1.SelectedIndex = 0;
            id = "0";

        }
        void getcombo()
        {
            comboBox1.DataSource = mod.getData("SELECT * FROM status");
            comboBox1.DisplayMember="status";
            comboBox1.ValueMember = "idstatus";



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Pengembalian_Load(object sender, EventArgs e)
        {
            getcombo();
          
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == "0")
            {
                mod.pesan("Pilih data terlebih dahulu");
            }
            else
            {
                if (mod.dialogForm("Apakah anda yakin sudah benar"))
                {
                    string sql = "UPDATE transaksi SET tanggal_peminjaman = '"+dateTimePicker1.Value.ToString("yyyy/MM/dd")+"',idstatus='"+comboBox1.SelectedValue+"'WHERE idpeminjaman="+id;
                    mod.exc(sql);
                    mod.clearForm(groupBox1);
                    awal();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mod.clearForm(groupBox1);
        }
    }
}
