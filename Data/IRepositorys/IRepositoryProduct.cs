using System;
using Models;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IRepositoryProduct
    {
        void Add(ProductEntity product);
        List<ProductEntity> GetAll();
        List<ProductEntity> GetByList(int id);
        ProductEntity GetById(int id);
        void Update(ProductEntity product);
        void Delete(int id);
    }
}
