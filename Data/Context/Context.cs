using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Context
    {
        public IRepositoryContact ContactRepo { get; set; } = new ContactRepository();
        public IRepositoryProduct ProductRepo { get; set; } = new ProductRepository();
        public IRepositoryOrder OrderRepo { get; set; } = new OrderRepository();
        public IRepositoryCatagory CategoryRepo { get; set; } = new CatagoryRepository();
    }
}
