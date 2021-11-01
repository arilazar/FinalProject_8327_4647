using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Planets
    {
        [Key]
        public string Name { get; set; }
        public string GeneralInfo { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string AvgDistanceFromSun { get; set; }
        public string OrbitalPeriod { get; set; }
        public string AvgOrbitalSpeed { get; set; }
        public string Inclination { get; set; }
        public string Satellites { get; set; }
        public string Radius { get; set; }
        public string SurfaceArea { get; set; }
        public string Mass { get; set; }
        public string Density { get; set; }
        public string RotationPeriod { get; set; }
        public string RotationSpeed { get; set; }
        public string AxialTilt { get; set; }
        public string AvgSurfaceTemp { get; set; }
        public string ImageUrl { get; set; }
    }


    public class PlanetsDB : DbContext
    {

        public PlanetsDB() : base("name=PlanetsDB")
        {


        }
        public DbSet<Planets> PlanetsDataSet { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
    }

}

//public partial class PlanetsDB_8327Entities2 : DbContext
//{
//    public PlanetsDB_8327Entities2()
//        : base("name=PlanetsDB_8327Entities2")
//    {
//    }

//    protected override void OnModelCreating(DbModelBuilder modelBuilder)
//    {
//        throw new UnintentionalCodeFirstException();
//    }

//    public virtual DbSet<Planets> Planets { get; set; }
//}
//}

