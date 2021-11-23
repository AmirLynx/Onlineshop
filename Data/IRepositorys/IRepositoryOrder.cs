using System;
using Models;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IRepositoryOrder
    {
        void Add(OrderEntity order);
        List<OrderEntity> GetAll();
        OrderEntity GetById(int id);
        void Update(OrderEntity order);
        void Delete(int id);
    }
}
