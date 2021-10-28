using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class NEO
    {
        public NEO(string date, long id, string name, double absoluteMagnitudeH, double estimatedDiameter, bool isPotentiallyHazardousAsteroid)
        {
            Date = date;
            Id = id;
            Name = name;
            AbsoluteMagnitudeH = absoluteMagnitudeH;
            EstimatedDiameter = estimatedDiameter;
            IsPotentiallyHazardousAsteroid = isPotentiallyHazardousAsteroid;
        }
        public string Date { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public double AbsoluteMagnitudeH { get; set; }
        public double EstimatedDiameter { get; set; }
        public bool IsPotentiallyHazardousAsteroid { get; set; }
    }
}
