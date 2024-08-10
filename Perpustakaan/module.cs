using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Perpustakaan
{
    class module
    {
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataTable dt;

        public readonly string NamaServer = "Data Source=DESKTOP-DF0KBGJ\\SQLEXPRESS;Initial Catalog=Perpustakaan_part2;Integrated Security=True";

        public SqlCommand cmd;

        public void koneksi()
        {
            conn = new SqlConnection(NamaServer);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        //untuk menutup koneksi data base
        public void closeKoneksi()
        {
            conn.Close();
            cmd.Dispose();
        }

        public DataTable getData(string sql)
        {
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                da = new SqlDataAdapter();
                dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                closeKoneksi();
            }
        }

        public int getCount(string sql)
        {
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                da = new SqlDataAdapter();
                dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                closeKoneksi();
            }
        }

        public object getValue(string sql, string col)
        {
            koneksi();
            object value = null;
            try
            {
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if (dr.IsDBNull(dr.GetOrdinal(col)))
                    {
                        return "";
                    }
                    else
                    {
                        value = dr[col];
                        return value;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
            finally
            {
                closeKoneksi();
            }
        }

        public bool exc(string sql)
        {
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                closeKoneksi();
            }
        }

        //untuk menyeleksi apakah ada data yang belum diisi
        public bool adakosong(GroupBox gb)
        {

            bool status = false;
            foreach (Control ct in gb.Controls)
            {
                TextBox textbox = ct as TextBox;
                if (textbox != null && textbox.Text.Trim() == string.Empty)
                {
                    return true;
                }
            }
            return false;
        }

        //untuk menghapus tulisan
        public void clearForm(GroupBox gb)
        {
            foreach (Control cl in gb.Controls)
            {

                if (cl is TextBox)
                {
                    TextBox tx = (TextBox)cl;
                    tx.Text = "";
                }
                else if (cl is NumericUpDown)
                {
                    NumericUpDown np = (NumericUpDown)cl;
                    np.Value = 0;
                }
                else if (cl is ComboBox)
                {
                    ComboBox cb = (ComboBox)cl;
                    cb.SelectedIndex = 0;
                }
            }
        }

        public void onlyNumber(KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                if (e.KeyChar < '0' || e.KeyChar > '9')
                {
                    e.Handled = true;
                }
            }
        }

        public bool dialogForm(string s)
        {
            DialogResult a = MessageBox.Show(s, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        public void pesan(string s)
        {
            MessageBox.Show(s);
        }

    }
}
