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
    public partial class CariBuku : Form 
    {
        module mod = new module();
<<<<<<< HEAD
=======
        public string namaBuku;
        string id, nama;
>>>>>>> 7f92eb215e310ccc9a1dcdaa5ad2c1d475bcc774
        MenuUtama mu;
      
        public void awal()
        {
            dataGridView1.DataSource = mod.getData("select * from buku where judul like '%" + textBox1.Text + "%' ");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "judul";
            dataGridView1.Columns[2].HeaderText = "penerbit";

        }
        public CariBuku(MenuUtama mu)
        {
            InitializeComponent();
            this.mu = mu;
        }

        private void CariBuku_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                    
                mu.textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                mu.idBuku = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                
                this.Close();
                
            }
        }

        private void CariBuku_Leave(object sender, EventArgs e)
        {

        }

        private void CariBuku_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

<<<<<<< HEAD
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
=======
        private void textBox1_TextChanged(object sender, EventArgs e)
>>>>>>> 7f92eb215e310ccc9a1dcdaa5ad2c1d475bcc774
        {

        }
    }
}
