using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Data
{
    class ProductRepository : IRepositoryProduct
    {
        List<ProductEntity> products = new List<ProductEntity>();
        public void Add(ProductEntity product)
        {
            products.Add(product);
        }

        public List<ProductEntity> GetAll()
        {
            return products;
        }

        public ProductEntity GetById(int id)
        {
            ProductEntity foundProduct = null;

            foreach (var item in products)
            {
                if (id.Equals(item.ProductId))
                {
                    foundProduct = item;
                    break;
                }
            }
            
            return foundProduct;
        }
        public List<ProductEntity> GetByList(int id)
        {
            List<ProductEntity> foundProduct = null;

            foreach (var item in products)
            {
                if (id.Equals(item.ProductId))
                {
                    foundProduct = products;
                    break;
                }
            }
            if (foundProduct == null)
            {
                throw new NullReferenceException("Product not found !");
            }
            return foundProduct;
        }

        public void Update(ProductEntity product)
        {
            ProductEntity foundProduct = null;

            foreach (var item in products)
            {
                if (product.ProductId == item.ProductId)
                {
                    foundProduct = item;
                    break;
                }
            }
            if (foundProduct == null)
            {
                throw new NullReferenceException("Product not Found !");
            }
            foundProduct.Name = product.Name;
            foundProduct.Price = product.Price;
            foundProduct.Entity = product.Entity;
            foundProduct.Catagory = product.Catagory;
        }
        public void Delete(int id)
        {
            ProductEntity foundContact = null;

            var foundProductEntity = 0;

            foreach (var item in products)
            {
                if (id.Equals(item.ProductId))
                {
                    foundContact = item;
                    foundProductEntity = item.Entity;
                    break;
                }

            }
            if (foundContact == null)
            {
                throw new NullReferenceException("Contact not found !");
            }
            if (foundProductEntity == 0)
            {
                throw new NullReferenceException("You cant delete this Contact ()");
            }

            products.Remove(foundContact);
        }
    }
}
