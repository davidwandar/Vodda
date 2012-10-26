using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Vodda.Models;

namespace Vodda.Controllers
{
    public class SFAnytimeController : SupplierBaseController
    {
        //
        // GET: /SFAnytime/

        public ActionResult Index()
        {
            return View();
        }


        public override bool Populate(Media media)
        {
            return false;
        }

        public void PopulateNew()
        {
            var m = new SupplierMedia();
            HtmlWeb docWeb = new HtmlWeb();
            var document = docWeb.Load("http://sfanytime.com/Templates/Storefront/Pages/MovieListProxy.aspx?nc=sv-SE-0&epslanguage=sv-SE&stripes=1,2,3&rtr=28&ob=StartDate+desc&mob=");
            var sb = new StringBuilder();
            List<SupplierMedia> list = new List<SupplierMedia>();
            foreach (HtmlNode link in document.DocumentNode.SelectNodes("//div[@class='backet_title']/a[@href]"))
            {
                m = new SupplierMedia();
                m.Name = GetName(link.Attributes["href"].Value);
                m.Url = "http://sfanytime.com" + link.Attributes["href"].Value;
                try
                {
                    string coverUrl = link.ParentNode.PreviousSibling.PreviousSibling.ChildNodes["img"].Attributes["src"].Value;
                    m.CoverUrl = coverUrl;
                }
                catch { }
                
                
                //list.Add(m);
                m.Put();
            }
            return;
        }

        private string GetName(string p)
        {
            HtmlWeb docWeb = new HtmlWeb();
            var document = docWeb.Load("http://sfanytime.com" + p);
            HtmlNode node = document.DocumentNode.SelectNodes("//title")[0];

            return node.InnerText.Trim().Replace("- SF Anytime", "").Trim();

        }
    }
}
