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

        public DbSet<Media> Medias { get; set; }
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
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public class SupplierMedia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Supplier Supplier { get; set; }
        public Media Media { get; set; }
        public string SupplierIdentifier { get; set; }
        public string SupplierMediaName { get; set; } // if diffrent than Media
        public string CoverUrl { get; set; } 
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
                    this.Media = GetMedia();
                    this.Created = DateTime.Now;
                    
                    db.SupplierMedias.Add(this);
                    db.SaveChanges();
                }
            }
                    
        }

        public Media GetMedia()
        {
            using (MediaContext db = new MediaContext())
            {
                Media media = db.Medias.FirstOrDefault(s => s.Name == this.Name);
                if (media == null)
                { 
                    //No such supplier, add new
                    Media m = new Media();
                    m.Name = this.Name;
                    m.CoverUrl = this.CoverUrl;
                    m.Created = DateTime.Now;

                    db.Medias.Add(m);
                    db.SaveChanges();

                    return m;
                }
                return media;
            }
            
        }
    }
}