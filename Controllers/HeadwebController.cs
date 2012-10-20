﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vodda.Models;

namespace Vodda.Controllers
{
    public class HeadwebController : SupplierBaseController
    {
        //
        // GET: /Headweb/

        public ActionResult Index()
        {
            return View();
        }

        public override bool Populate(Media media)
        {
            /* Is media already registred at this supplier 
             *  + has interval passed
             *   + search by supplieridentifier
             *    + update properties (price etc)
             *    - search by title
             *     + update
             *     - delete
             *   - return
             *  - search by title
             * 
             * 
             * */
            return true;
        }

    }
}