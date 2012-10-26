using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vodda.Models;

namespace Vodda.Controllers
{
    public abstract class SupplierBaseController : Controller
    {
        protected string _supplierId; // Id from D
        public abstract bool Populate(Media media);

        public static string GetUrlData(string Url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
                request.Timeout = 4000;
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch
            {
                return String.Empty;
            }

        }
        
    }
}