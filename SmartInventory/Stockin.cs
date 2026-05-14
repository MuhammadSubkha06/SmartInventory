using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartInventory
{
    public partial class Stockin : Form
    {
        private int productId;

        public Stockin(int id, string productName, int currentStock)
        {
            InitializeComponent();

            this.productId = id;

            txtProductName.Text = productName;
            txtCurrentStock.Text = currentStock.ToString();
            txtCurrentStock.ReadOnly = true;
            txtCurrentStock.BackColor = Color.LightGray;
        }

        private void Stockin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int quantityToAdd) || quantityToAdd <= 0)
            {
                MessageBox.Show("Masukkan jumlah angka yang valid!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(koneksi.conString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE products SET stock = stock + @qty WHERE id_product = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@qty", quantityToAdd);
                        cmd.Parameters.AddWithValue("@id", this.productId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Berhasil Disimpan!");
                            this.DialogResult = DialogResult.OK; 
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Gagal update: ID tidak ditemukan.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kesalahan: " + ex.Message);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
