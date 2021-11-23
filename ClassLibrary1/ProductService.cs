using System;
using Data;
using Models;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProductService
    {
        private readonly Context _context;
        public ProductService()
        {
            _context = new Context();
        }
        public void Add(ProductEntity product)
        {
            _context.ProductRepo.Add(product);
        }

        public List<ProductEntity> GetAll()
        {
            return _context.ProductRepo.GetAll();
        }

        public ProductEntity GetById(int id)
        {
            return _context.ProductRepo.GetById(id);
        }

        public void Update(ProductEntity product)
        {
            _context.ProductRepo.Update(product);
        }
        public void Delete(int id)
        {
            _context.ProductRepo.Delete(id);
        }
        public List<ProductEntity> GetByList(int id)
        {
            
            return _context.ProductRepo.GetByList(id);
        }
    }
}
