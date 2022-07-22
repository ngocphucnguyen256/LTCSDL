using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenNgocPhuc
{
    class Product
    {
        private int productId;
        private string productName;
        private int supplierId;
        private int categoryId;
        private int quantity;
        private double unitPrice;

        public int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public int SupplierId
        {
            get
            {
                return supplierId;
            }

            set
            {
                supplierId = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return categoryId;
            }

            set
            {
                categoryId = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
            }
        }
    }
}
