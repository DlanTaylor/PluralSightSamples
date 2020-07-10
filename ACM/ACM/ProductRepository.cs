using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    public class ProductRepository
    {

        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            if(productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted set of Sunflowers";
                product.CurrentPrice = 15.96M;
            }

            return product;
        }

        public bool Save(Product product)
        {
            var success = true;
            if (product.HasChanges)
            {
                if (product.Isvalid)
                {
                    if (product.IsNew)
                    {
                        // call an Insert stored procedure

                    }
                    else
                    {
                        // Call an update procedure
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
