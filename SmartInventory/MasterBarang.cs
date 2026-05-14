using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SmartInventory
{
    public partial class MasterBarang : Form
    {
        public MasterBarang()
        {
            InitializeComponent();


            tampilBarang();
            loadKategori();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tampilBarang(string search = "", string kategori = "")
        {
            using (SqlConnection connection = new SqlConnection(koneksi.conString))
            {
                string query = @"
                                SELECT 
                                    p.id_product,
                                    p.sku, 
                                    p.name_product, 
                                    c.name_category, 
                                    p.price, 
                                    p.stock,
                                    p.min_threshold,
                                    CASE
                                        WHEN p.stock = 0 THEN 'Out of Stock'
                                        WHEN p.stock <= p.min_threshold THEN 'Low Stock'
                                        ELSE 'In Stock'
                                    END AS status
                                    FROM products p
                                    INNER JOIN categories c ON p.id_category = c.id_category
                                    WHERE 
                                        (@search = '' OR p.name_product LIKE '%' + @search + '%' OR p.sku LIKE '%' + @search + '%')
                                        AND (@kategori = '' OR c.name_category = @kategori)
                                    ";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@search", search);
                cmd.Parameters.AddWithValue("@kategori", kategori);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dataGridView1.Columns.Contains("id_product"))
                {
                    dataGridView1.Columns["id_product"].Visible = false;
                }
            }
        }

        private void loadKategori()
        {
            using (SqlConnection conn = new SqlConnection(koneksi.conString))
            {
                string query = "SELECT name_category FROM categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.Items.Clear();
                comboBox1.Items.Add("");

                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row["name_category"].ToString());
                }
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tampilBarang(textBox1.Text, comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilBarang(textBox1.Text, comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                EditProducts edit = new EditProducts();
                edit.sku = row.Cells["sku"].Value.ToString();
                edit.name = row.Cells["name_product"].Value.ToString();
                edit.price = row.Cells["price"].Value.ToString();
                edit.category = row.Cells["name_category"].Value.ToString();
                edit.ShowDialog();

                tampilBarang(textBox1.Text, comboBox1.Text);
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "StockIn")
            {
                int id = Convert.ToInt32(row.Cells["id_product"].Value);
                string nama = row.Cells["name_product"].Value.ToString();
                int stokSekarang = Convert.ToInt32(row.Cells["stock"].Value);

                Stockin frmStockIn = new Stockin(id, nama, stokSekarang);

                if (frmStockIn.ShowDialog() == DialogResult.OK)
                {
                    tampilBarang(textBox1.Text, comboBox1.Text);
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "StockOut")
            {
                int id = Convert.ToInt32(row.Cells["id_product"].Value);
                string nama = row.Cells["name_product"].Value.ToString();
                int stokSekarang = Convert.ToInt32(row.Cells["stock"].Value);

                StockOut frmStockIn = new StockOut(id, nama, stokSekarang);

                if (frmStockIn.ShowDialog() == DialogResult.OK)
                {
                    tampilBarang(textBox1.Text, comboBox1.Text);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
