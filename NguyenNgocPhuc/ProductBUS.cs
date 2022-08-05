using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace NguyenNgocPhuc
{
    class ProductBUS
    {
        private ProductDAL productDAL;



        public ProductBUS()
        {
            productDAL = new ProductDAL();
        }

        public DataTable GetProducts()
        {
            return productDAL.GetProducts();
        }

        public void GetCategories(ComboBox c)
        {
            c.DataSource = productDAL.GetCategories();
            c.DisplayMember = "CategoryName";
            c.ValueMember = "CategoryID";
        }

        public void GetSuppliers(ComboBox c)
        {
            c.DataSource = productDAL.GetSuppliers();
            c.DisplayMember = "CompanyName";
            c.ValueMember = "SupplierID";
        }
        public bool AddProduct(ProductClass p)
        {
            bool result = true;
            if (!productDAL.CheckProductName(p))
            {
                result = productDAL.AddProduct(p);
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool UpdateProduct(ProductClass p)
        {
            bool result = false;
            if (productDAL.CheckProductID(p.ProductId))
            {
                result = productDAL.UpdateProduct(p);
            }

            return result;
        }

        public bool DelProduct(int id)
        {
            bool result = false;
            if (productDAL.CheckProductID(id))
            {
                result = productDAL.DelProduct(id);
            }

            return result;
        }



    }
}
