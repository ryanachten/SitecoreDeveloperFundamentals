using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingCompany.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ClothingCompany.Controllers
{
    public class NavController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            Item homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            IEnumerable<NavItem> GetNavItems(Item navRoot)
            {
                var items = new List<Item> { navRoot };
                ID contentItemId = new Sitecore.Data.ID("{77E1B420-FABC-4CA7-BEBF-B0BEA60BB92E}");
                items.AddRange(navRoot.Children.Where(item => item.DescendsFrom(contentItemId)));
                var navItems = items.Select(item => new NavItem
                {
                    Item = item,
                    Url = LinkManager.GetItemUrl(item),
                });
                return navItems;
            }

            var navLinks = new NavGroup
            {
                RootItem = homeItem,
                RootUrl = LinkManager.GetItemUrl(homeItem),
                NavItems = GetNavItems(homeItem)
            };

            return View(navLinks);
        }
    }
}