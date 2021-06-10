using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuffAPI_Sergio.Models
{
    public partial class ItemLocalization
    {
        public ItemLocalization()
        {
            Items = new HashSet<Item>();
        }

        public int ItemLocalizationId { get; set; }
        public string Localization { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
