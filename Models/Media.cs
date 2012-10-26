using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Vodda.Models
{
    public class SupplierMediaContext : DbContext
    {
        public SupplierMediaContext() : base("DefaultConnection")
        {
        }

        public DbSet<SupplierMedia> SupplierMedias { get; set; }
    }

    public class MediaContext : DbContext
    {
        public MediaContext() : base("DefaultConnection")
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
    }

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
        public DateTime Updated { get; set; }
    }

    public class SupplierMedia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Supplier Supplier { get; set; }
        public string SupplierIdentifier { get; set; }
        public string SupplierName { get; set; } // if diffrent than Media
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Url { get; set; }

        public void Put()
        {
            using (SupplierMediaContext db = new SupplierMediaContext())
            {
                SupplierMedia sm = db.SupplierMedias.FirstOrDefault(s => s.Url == this.Url);
                if (sm == null)
                { 
                    //Does not exist, add new

                }
            }
                    
        }

        public Supplier Supplier()
        {
            using (MediaContext db = new MediaContext())
            {
                Supplier supplier = db.Suppliers.FirstOrDefault(s => s.Name == this.Name);
                if (supplier == null)
                { 
                    //No such supplier, add new
                    Supplier s = new Supplier();
                    s.Name = this.Name;
                    s

                }
            }
        }
    }
}