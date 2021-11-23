using System;

namespace Models
{
    public class ContactEntity
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string PassWord { get; set; }
        public int OrderCounter { get; set; }
    }
}
