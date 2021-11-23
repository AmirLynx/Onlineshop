using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CatagoryEntity
    {
        public enum Used
        {
            used,notused
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Used used { get; set; }
    }
}
