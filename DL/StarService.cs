using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace DL
{
    public class StarService
    {
        /*PlanetsDB_8327Entities2 ObjContext;

        public StarService()
        {
            ObjContext = new PlanetsDB_8327Entities2();

            //new Thread(() =>
            //{
            //    using (var dbcontext = new PlanetsDB_8327Entities2())
            //    {
            //        if (dbcontext.Planets.ToList().Count == 0)
            //        {
            //            //var a = JsonConvert.DeserializeObject<Dictionary<string, string>>(new StreamReader(@"../../../DAL/Description.json").ReadToEnd());
            //            //var link = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2F";
            //            dbcontext.Planets.Add(new Planets()
            //            {
            //                Name = "a",
            //                GeneralInfo = "b",
            //                Category = "b",
            //                Location = "b",
            //                AvgDistanceFromSun = "b",
            //                OrbitalPeriod = "b",
            //                AvgOrbitalSpeed = "b",
            //                Inclination = "b",
            //                Satellites = "b",
            //                Radius = "b",
            //                SurfaceArea = "b",
            //                Mass = "b",
            //                Density = "b",
            //                RotationPeriod = "b",
            //                RotationSpeed = "b",
            //                AxialTilt = "b",
            //                AvgSurfaceTemp = "b",
            //                ImageUrl = "b"
            //            });
            //            dbcontext.SaveChanges();
            //        }
            //    }
            //}).Start();
        }

        public List<Star> GetPlanets()
        {
            List<Star> ObjStarList = new List<Star>();
            try
            {
                var ObjQuery = from obj in ObjContext.Planets
                               select obj;
                foreach (var star in ObjQuery)
                {
                    ObjStarList.Add(new Star
                    {
                        Name = star.Name,
                        GeneralInfo = star.GeneralInfo,
                        Category = star.Category,
                        Location = star.Location,
                        AvgDistanceFromSun = star.AvgDistanceFromSun,
                        OrbitalPeriod = star.OrbitalPeriod,
                        AvgOrbitalSpeed = star.AvgOrbitalSpeed,
                        Inclination = star.Inclination,
                        Satellites = star.Satellites,
                        Radius = star.Radius,
                        SurfaceArea = star.SurfaceArea,
                        Mass = star.Mass,
                        Density = star.Density,
                        RotationPeriod = star.RotationPeriod,
                        RotationSpeed = star.RotationSpeed,
                        AxialTilt = star.AxialTilt,
                        AvgSurfaceTemp = star.AvgSurfaceTemp,
                        ImageUrl = star.ImageUrl
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjStarList;
        }*/
        /*
        public bool Add(EmployeeDTO objNewEmployee)
        {
            bool IsAdded = false;
            //Age must be between 21 and 58
            if (objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
                throw new ArgumentException("Invalid age limit for employee");

        try
        {
            var ObjEmployee = new Employee();
            ObjEmployee.Id = objNewEmployee.Id;
            ObjEmployee.Name = objNewEmployee.Name;
            ObjEmployee.Age = objNewEmployee.Age;

            ObjContext.Employees.Add(ObjEmployee);
            var NoOfRowsAffected = ObjContext.SaveChanges();
            IsAdded = NoOfRowsAffected > 0;
        }
        catch (SqlException ex)
        {

            throw ex;
        }

        return IsAdded;
    }

    public bool Update(EmployeeDTO objEmployeeToUpdate)
    {
        bool IsUpdated = false;

        try
        {
            var ObjEmployee = ObjContext.Employees.Find(objEmployeeToUpdate.Id);
            ObjEmployee.Name = objEmployeeToUpdate.Name;
            ObjEmployee.Age = objEmployeeToUpdate.Age;
            var NoOfRowsAffected = ObjContext.SaveChanges();
            IsUpdated = NoOfRowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return IsUpdated;
    }

    public bool Delete(int id)
    {
        bool IsDeleted = false;
        try
        {
            var ObjEmployeeToDelete = ObjContext.Employees.Find(id);
            ObjContext.Employees.Remove(ObjEmployeeToDelete);
            var NoOfRowsAffected = ObjContext.SaveChanges();
            IsDeleted = NoOfRowsAffected > 0;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return IsDeleted;
    }

    public EmployeeDTO Search(int id)
    {
        EmployeeDTO ObjEmployee = null;

        try
        {
            var ObjEmployeeToFind = ObjContext.Employees.Find(id);
            if (ObjEmployeeToFind != null)
            {
                ObjEmployee = new EmployeeDTO()
                {
                    Id = ObjEmployeeToFind.Id,
                    Name = ObjEmployeeToFind.Name,
                    Age = ObjEmployeeToFind.Age
                };
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ObjEmployee;
    }*/
}