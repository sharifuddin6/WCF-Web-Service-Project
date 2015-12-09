using System;
using System.Collections.Generic;
using System.Linq;
using Web_Service_Project.Entity;

namespace Web_Service_Project
{
    public class InventoryService : IInventoryService
    {
        public Product GetProduct(int productId)
        {
            using (var context = new EntityContainer())
            {
                try
                {
                    var product = context.pProducts.Single(p => p.ProductId == productId);
                    return new Product
                    {
                        ProductId = product.ProductId,
                        Title = product.Title,
                        Author = product.Author,
                        Abstract = product.Abstract,
                        Content = product.Content,
                        Thumbnail = product.Thumbnail,
                        DateAdded = product.DateAdded
                    };
                }
                catch (InvalidOperationException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var context = new EntityContainer())
            {
                return Enumerable.Cast<Product>(context.pProducts.Select(p => new Product()
                {
                    ProductId = p.ProductId,
                    Title = p.Title,
                    Author = p.Author,
                    Abstract = p.Abstract,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail
                })).ToList();
            }
        }

        public bool AddProduct(Product product)
        {
            using (var context = new EntityContainer())
            {
                try
                {
                    context.pProducts.Add(new pProduct
                    {
                        Title = product.Title,
                        Author = product.Author,
                        Abstract = product.Abstract,
                        Content = product.Content,
                        Thumbnail = product.Thumbnail,
                        DateAdded = product.DateAdded
                    });
                    context.SaveChanges();
                    return true;
                }
                catch (InvalidOperationException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public bool RemoveProduct(int productId)
        {
            using (var context = new EntityContainer())
            {
                try
                {
                    var product = context.pProducts.Single(p => p.ProductId == productId);
                    context.pProducts.Remove(product);
                    context.SaveChanges();
                    return true;
                }
                catch (InvalidOperationException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
