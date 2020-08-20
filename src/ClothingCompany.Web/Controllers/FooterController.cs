using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingCompany.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ClothingCompany.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            var footerFolder = Sitecore.Context.Database.GetItem("/sitecore/content/Home/Resources");
            
            IEnumerable<NavItem> GetNavItems(Item navRoot)
            {
                var items = new List<Item> { navRoot };
                items.AddRange(navRoot.Children); // Tutorial restricts this by an ID?
                var navItems = items.Skip(1).Select( item => new NavItem
                {
                    Item = item,
                    Url = LinkManager.GetItemUrl(item),
                });
                return navItems;
            }

            var footerLinks = new NavGroup
            {
                RootItem = footerFolder,
                RootUrl = LinkManager.GetItemUrl(footerFolder),
                NavItems = GetNavItems(footerFolder)
            };

            return View(footerLinks);
        }
    }
}