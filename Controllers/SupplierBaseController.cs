using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vodda.Models;

namespace Vodda.Controllers
{
    public abstract class SupplierBaseController : Controller
    {
        protected string _supplierId; // Id from D
        public abstract bool Populate(Media media);
        
    }
}