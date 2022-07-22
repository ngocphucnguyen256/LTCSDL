using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace NguyenNgocPhuc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        private void ConnectDb()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        private DataTable LoadListProduct()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "Select * from Products";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        private DataTable LoadCategories()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "Select CategoryID,CategoryName from Categories";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        private DataTable LoadSuppliers()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "Select SupplierID,CompanyName from Suppliers";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        private bool AddProduct(Product p)
        {
            bool flag = false;
            SqlCommand sqlCom;
            string queryStr = string.Format("insert into Products(ProductName, SupplierID, CategoryID,QuantityPerUnit, UnitPrice) values(N'{0}',{1},{2},{3},{4})",
                p.ProductName,p.SupplierId,p.CategoryId,p.Quantity,p.UnitPrice);
            sqlCom = new SqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                sqlCom.ExecuteNonQuery();
                flag = true;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return flag;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectDb();
            gvSanPham.DataSource = LoadListProduct();
            


            cbLoaiSP.DataSource = LoadCategories();
            cbLoaiSP.DisplayMember = "CategoryName";
            cbLoaiSP.ValueMember = "CategoryID";


            cbNCC.DataSource = LoadSuppliers();
            cbNCC.DisplayMember = "CompanyName";
            cbNCC.ValueMember = "SupplierID";

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            try
            {
               p.ProductName = txtTenSP.Text.ToString();

                p.Quantity = int.Parse(txtSoLuong.Text);
                p.UnitPrice = double.Parse(txtDonGia.Text);
                p.CategoryId = int.Parse(cbLoaiSP.SelectedValue.ToString());
                p.SupplierId = int.Parse(cbNCC.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (AddProduct(p))
            {
                MessageBox.Show("Them thanh cong");
                gvSanPham.DataSource = LoadListProduct();
            }
            else
            {
                MessageBox.Show("Them that bai");

            }


        }
    }

}
