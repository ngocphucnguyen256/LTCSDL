using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace NguyenNgocPhuc
{
    class ProductDAL
    {
        public ProductDAL()
        {
            ConnectDb();
        }
        SqlConnection conn;
        private void ConnectDb()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        public DataTable GetProducts()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "Select * from Products";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            //string query = "Select CategoryID,CategoryName from Categories";
            string query = "Select * from Categories";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        public bool CheckProductName(ProductClass p)
        {
            bool flag = false;
            int n = 0;
            SqlCommand sqlCom;
            string queryStr = string.Format("select count(*) from Products where ProductName=N'{0}'", p.ProductName);
            sqlCom = new SqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                sqlCom.ExecuteNonQuery();
                n = int.Parse(sqlCom.ExecuteScalar().ToString());
                flag = n > 0 ? true : false;

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


        public bool CheckProductID(int id)
        {
            bool flag = false;
            int n = 0;
            SqlCommand sqlCom;
            string queryStr = string.Format("select count(*) from Products where ProductID={0}", id);
            sqlCom = new SqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                sqlCom.ExecuteNonQuery();
                n = int.Parse(sqlCom.ExecuteScalar().ToString());
                flag = n > 0 ? true : false;

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

        public DataTable GetSuppliers()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "Select SupplierID,CompanyName from Suppliers";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        public bool AddProduct(ProductClass p)
        {
            bool flag = false;
            SqlCommand sqlCom;
            string queryStr = string.Format("insert into Products(ProductName, SupplierID, CategoryID,QuantityPerUnit, UnitPrice) values(N'{0}',{1},{2},{3},{4})",
                p.ProductName, p.SupplierId, p.CategoryId, p.Quantity, p.UnitPrice);
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


        public bool UpdateProduct(ProductClass p)
        {
            bool flag = false;


            SqlCommand sqlCom;
            string queryStr = string.Format("update Products set ProductName = N'{0}', SupplierID={1}, CategoryID={2},QuantityPerUnit={3}, UnitPrice={4} where ProductID={5}",
                p.ProductName, p.SupplierId, p.CategoryId, p.Quantity, p.UnitPrice, p.ProductId);
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
        public bool DelProduct(int id)
        {
            bool flag = false;
            SqlCommand sqlCom;
            string queryStr = string.Format("delete from Products where ProductID = {0}",
                id);
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






    }
}
