using Sitecore.Data.Items;
using System.Collections.Generic;

namespace ClothingCompany.Models
{
    public class NavGroup
    {
        public Item RootItem { get; set; }
        public string RootUrl { get; set; }
        public IEnumerable<NavItem> NavItems { get; set; }

    }
}