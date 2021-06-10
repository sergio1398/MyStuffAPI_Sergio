using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuffAPI_Sergio.Models
{
    public partial class Item
    {
        public Item()
        {
            Multimedia = new HashSet<Multimedium>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemCost { get; set; }
        public string SerialNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal ExRate { get; set; }
        public int? BrandId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? ItemLocalizationId { get; set; }
        public int? SupplierId { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemLocalization ItemLocalization { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Multimedium> Multimedia { get; set; }
    }
}
