using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAPI.Repository
{
    public class ProductRepository : DbContext
    {
        public List<Product> Get()
        {
            List<Product> productsList = new List<Product>()
            {
                new Product {ProductID=1, ProductName="Dell",ProductFeatures="I3",ProductPrice=1000, Status= true },
                new Product {ProductID=2, ProductName="Hp", ProductFeatures="I4",ProductPrice=2000, Status = true },
                new Product {ProductID=3, ProductName="Lenovo", ProductFeatures="I5",ProductPrice=3000, Status = false},
                new Product {ProductID=3, ProductName="Acer", ProductFeatures="I5",ProductPrice=4000, Status = false}
            };
            return productsList;
        }

        public Product GetBy(int id)
        {
            List<Product> productsList = Get();
            Product product = productsList.Where(x => x.ProductID == id).FirstOrDefault();
            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public List<Product> Create(Product product)
        {
            List<Product> productsList = Get();
            productsList.Add(product);
            return productsList;
        }

        public List<Product> Delete(int id)
        {
            List<Product> productsList = Get();
            var itemToRemove = productsList.SingleOrDefault(r => r.ProductID == id);
            if (itemToRemove != null)
            {
                productsList.Remove(itemToRemove);
                return productsList;
            }
            else
            {
                return null;
            }
        }

        public List<Product> Update(Product product)
        {
            List<Product> productsList = Get();
            var updateProduct = productsList.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
            if (updateProduct != null)
            {
                updateProduct.ProductName = product.ProductName;
                updateProduct.ProductFeatures = product.ProductFeatures;
                updateProduct.ProductPrice = product.ProductPrice;
                return productsList;
            }
            else
            {
                return null;
            }
        }

        public Product UpdateByPatch(int id, JsonPatchDocument<Product> product)
        {
            List<Product> productsList = Get();
            var result = productsList.FirstOrDefault(n => n.ProductID == id);
            if (result == null)
            {
                return null;
            }
            product.ApplyTo(result);//result gets the values from the patch request
            return result;
        }

        public List<Product> GetActiveOrDeactiveProducts(bool status)
        {
            List<Product> productsList = Get();
            productsList = productsList.FindAll(x => x.Status == status).ToList();
            if (productsList != null)
            {
                return productsList;
            }
            else
            {
                return null;
            }
        }
    }
}
