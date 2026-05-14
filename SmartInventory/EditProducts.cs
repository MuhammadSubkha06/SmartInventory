using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SmartInventory
{
    public partial class EditProducts : Form
    {
        public string sku, name, price, stock, category;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
                return;
            }

            if (!decimal.TryParse(textBox3.Text, out decimal harga))
            {
                MessageBox.Show("Harga harus angka!");
                return;
            }


            using (SqlConnection conn = new SqlConnection(koneksi.conString))
            {
                string query = @"UPDATE products 
                         SET name_product = @name,
                             id_category = @category,
                             price = @price
                         WHERE sku = @sku";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@category", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@price", harga);
                cmd.Parameters.AddWithValue("@sku", textBox1.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil diupdate!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public EditProducts()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditProducts_Load(object sender, EventArgs e)
        {
            textBox1.Text = sku;            
            textBox2.Text = name;           
            textBox3.Text = price;          

            loadKategori();

            comboBox1.Text = category;      
        }


        private void loadKategori()
        {
            using (SqlConnection conn = new SqlConnection(koneksi.conString))
            {
                string query = "SELECT id_category, name_category FROM categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "name_category";
                comboBox1.ValueMember = "id_category";
            }
        }
    }
}
