using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Data
{
    class OrderRepository : IRepositoryOrder
    {
        List<OrderEntity> orders = new List<OrderEntity>();
        public void Add(OrderEntity order)
        {
            orders.Add(order);
        }

        public List<OrderEntity> GetAll()
        {
            return orders;
        }
        public void Delete(int id)
        {
            OrderEntity foundOrder = null;
            
            foreach (var item in orders)
            {
                if (id.Equals(item.OrderId) && item.paystatus != OrderEntity.Paystatus.pay)
                {
                    foundOrder = item;
                    break;
                }
            }
            orders.Remove(foundOrder);
        }

        public OrderEntity GetById(int id)
        {
            OrderEntity foundOrder = null;

            foreach (var item in orders)
            {
                if(id.Equals(item.OrderId))
                {
                    foundOrder = item;
                    break;
                }
            }
            
            return foundOrder;
        }

        public void Update(OrderEntity order)
        {
            OrderEntity foundOrder = null;

            foreach (var item in orders)
            {
                if (order.OrderId == item.OrderId)
                {
                    foundOrder = item;
                    break;
                }
            }
            if (foundOrder == null)
            {
                throw new NullReferenceException("Order not Found !");
            }
            foundOrder.Status = order.Status;
            foundOrder.Entity = order.Entity;
            foundOrder.OwnerId = order.OwnerId;
        }
    }
}
