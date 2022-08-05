using System;
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
        private ProductBUS busProduct;
        public Form1()
        {
            InitializeComponent();
            busProduct = new ProductBUS();
        }

        static int productId;
        private void Form1_Load(object sender, EventArgs e)
        {

            gvSanPham.DataSource = busProduct.GetProducts();
            busProduct.GetCategories(cbLoaiSP);
            busProduct.GetSuppliers(cbNCC);


        }
        private void ReloadProducts()
        {
            gvSanPham.DataSource = busProduct.GetProducts();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            bool result = false;
            ProductClass p = new ProductClass();

            try
            {
                p.ProductName = txtTenSP.Text.ToString();

                p.Quantity = int.Parse(txtSoLuong.Text);
                p.UnitPrice = double.Parse(txtDonGia.Text);
                p.CategoryId = int.Parse(cbLoaiSP.SelectedValue.ToString());
                p.SupplierId = int.Parse(cbNCC.SelectedValue.ToString());
                result = busProduct.AddProduct(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            switch (result)
            {
                case false:
                    MessageBox.Show("Them that bai");
                    break;
                case true:
                    MessageBox.Show("Them thanh cong");
                    ReloadProducts();
                    break;



            }



        }

        private void btSua_Click(object sender, EventArgs e)
        {
            bool result = false;
            ProductClass p = new ProductClass();

            try
            {
                p.ProductName = txtTenSP.Text;
                p.Quantity = int.Parse(txtSoLuong.Text);
                p.UnitPrice = double.Parse(txtDonGia.Text);
                p.CategoryId = int.Parse(cbLoaiSP.SelectedValue.ToString());
                p.SupplierId = int.Parse(cbNCC.SelectedValue.ToString());
                p.ProductId = productId;
                result = busProduct.UpdateProduct(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            switch (result)
            {
                case false:
                    MessageBox.Show("Sua that bai");
                    break;
                case true:
                    MessageBox.Show("Sua thanh cong");
                    ReloadProducts();
                    break;



            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            bool result = false;


            try
            {
                result = busProduct.DelProduct(productId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            switch (result)
            {
                case false:
                    MessageBox.Show("Xoa that bai");
                    break;
                case true:
                    MessageBox.Show("Xoa thanh cong");
                    ReloadProducts();
                    break;

            }


        }



        private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > 0 && e.RowIndex < gvSanPham.Rows.Count)
                {
                    productId = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
                    txtTenSP.Text = gvSanPham.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                    cbLoaiSP.SelectedValue = gvSanPham.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                    cbNCC.SelectedValue = gvSanPham.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString();
                    txtDonGia.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    txtSoLuong.Text = gvSanPham.Rows[e.RowIndex].Cells["QuantityPerUnit"].Value.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Tu tu thoi");
            }



        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
