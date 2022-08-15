using ProductsAPI.IServices;
using System;
using System.Collections.Generic;
using ProductsAPI.Repository;
using Microsoft.AspNetCore.JsonPatch;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        public List<Product> Create(Product product)
        {
            List<Product> productsList = new ProductRepository().Create(product);
            return productsList;
        }

        public List<Product> Delete(int id)
        {
            List<Product> productsList = new ProductRepository().Delete(id);
            return productsList;
        }

        public List<Product> Get()
        {
            List<Product> productsList = new ProductRepository().Get();
            return productsList;
        }

        public Product GetBy(int id)
        {
            Product product = new ProductRepository().GetBy(id);
            return product;
        }

        public List<Product> Update(Product product)
        {
            List<Product> productsList = new ProductRepository().Update(product);
            return productsList;
        }

        public Product UpdateByPatch(int id, JsonPatchDocument<Product> product)
        {
            Product updatedProduct = new ProductRepository().UpdateByPatch(id, product);
            return updatedProduct;
        }

        public List<Product> GetActiveOrDeactiveProducts(bool status)
        {
            List<Product> productsList = new ProductRepository().GetActiveOrDeactiveProducts(status);
            return productsList;
        }
        public bool IsValidUserInformation(LoginModel model)
        {
            if (model.UserName.Equals("Rahul") && model.Password.Equals("Wipro")) return true;
            else return false;
        }
        public List<LoginModel> GetUserDetails()
        {
            List<LoginModel> userListList = new List<LoginModel>()
            {
                new LoginModel {UserName="Rahul", Password="Wipro" },
                new LoginModel {UserName="abc", Password="123" },
            };
            return userListList;
        }
    }
}
