﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingCompany.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ClothingCompany.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            // TODO: should point to the /Home/Resources folder
            var footerFolder = Sitecore.Context.Database.GetItem("/sitecore/content/Home");
            
            IEnumerable<NavItem> GetNavItems(Item navRoot)
            {
                var items = new List<Item> { navRoot };
                ID contentItemId = new Sitecore.Data.ID("{77E1B420-FABC-4CA7-BEBF-B0BEA60BB92E}");
                items.AddRange(navRoot.Children.Where( item => item.DescendsFrom(contentItemId)));
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