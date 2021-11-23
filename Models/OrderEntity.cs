using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OrderEntity
    {
        public enum status
        {
            notPay,inProccess,sendpost,sendtoAdress
        }
        public enum Paystatus
        {
            pay,notPay
        }
        public Paystatus paystatus { get; set; }
        public status Status { get; set; }
        public int OrderId { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
        public int Entity { get; set; }
    }

}
