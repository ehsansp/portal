using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShahrKoodak.Core.Convertors;
using ShahrKoodak.Core.Generator;
using ShahrKoodak.DataLayer.Context;

namespace ShahrKoodak.Web.Controllers
{
    public class SiteMap : Controller
    {
        private ShahrContext _context;

        public SiteMap(ShahrContext context)
        {
            _context = context;
        }
        [Route("/sitemap.xml")]
        public async Task<ActionResult> Index()
        {
            // list of items to add
            var posts = await _context.Product.ToListAsync();

            var siteMapBuilder = new SiteMapBuilder();

            // add the blog posts to the sitemap
            foreach (var post in posts)
            {
                DateTime? date;
                if (post.UpdateDate == null)
                    date = post.CreateDate;
                else
                {
                    date = post.UpdateDate;
                }
                string friendlyTitle = FriendlyUrlHelper.GetFriendlyTitle(post.ProductTitle);
                siteMapBuilder.AddUrl("http://www.bingomarket.ir/ShowProduct/" + post.ProductId + "/" + friendlyTitle, modified: date, changeFrequency: null, priority: 0.8);
            }

            

            // generate the sitemap xml
            string xml = siteMapBuilder.ToString();
            return Content(xml, "text/xml");
        }
    }
}
