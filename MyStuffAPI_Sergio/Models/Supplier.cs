using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuffAPI_Sergio.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Items = new HashSet<Item>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
