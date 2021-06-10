using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuffAPI_Sergio.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Items = new HashSet<Item>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySym { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
