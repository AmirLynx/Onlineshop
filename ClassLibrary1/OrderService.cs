using System;
using Data;
using Models;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrderService
    {
        private readonly Context _context;

        public OrderService()
        {
            _context = new Context();
        }

        public void Add(OrderEntity order)
        {
            _context.OrderRepo.Add(order);
        }

        public List<OrderEntity> GetAll()
        {
            return _context.OrderRepo.GetAll();
        }

        public OrderEntity GetById(int id)
        {
            return _context.OrderRepo.GetById(id);
        }

        public void Update(OrderEntity order)
        {
            _context.OrderRepo.Update(order);
        }
        public void Delete (int id)
        {
            _context.OrderRepo.Delete(id);
        }
    }
}
