using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartInventory
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
            loadKategori();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Semua data wajib diisi!");
                return;
            }

            if (!decimal.TryParse(textBox3.Text, out decimal price))
            {
                MessageBox.Show("Harga harus angka!");
                return;
            }

            if (!int.TryParse(textBox4.Text, out int stock))
            {
                MessageBox.Show("Stock harus angka!");
                return;
            }

            using (SqlConnection connection = new SqlConnection(koneksi.conString))
            {
                string query = @"
                                INSERT INTO products 
                                (sku, name_product, id_category, price, stock, min_threshold, description, image)
                                VALUES 
                                (@sku, @name_product, @id_category, @price, @stock, @min_threshold, @description, @image)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sku", textBox1.Text.Trim());
                    command.Parameters.AddWithValue("@name_product", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@id_category", comboBox1.SelectedValue);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@stock", stock);

                    command.Parameters.AddWithValue("@min_threshold", 5);
                    command.Parameters.AddWithValue("@description", ""); 
                    command.Parameters.AddWithValue("@image", "default.png");

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Product berhasil ditambahkan!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan produk.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
