using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vodda.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
    }

    public class Media
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverUrl { get; set; }
    }

    public class SupplierMedia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Supplier Supplier { get; set; }
        public string SupplierIdentifier { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Üpdated { get; set; }
        public string Url { get; set; }
    }
}