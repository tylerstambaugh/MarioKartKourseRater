using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantRater.Models
{
    public class Kourse
    {
        public int KourseId { get; set; }
        [Required]
        [Display (Name = "Kourse Name")]
        public string Name { get; set; }
        public string Cup { get; set; }
        public int Rating { get; set; }
    }

    public class KourseDbContext : DbContext
    {
        public DbSet<Kourse> Kourses { get; set; }
    }
}