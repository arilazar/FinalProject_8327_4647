
using System.ComponentModel;

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
            IsPotentiallyHazardous = isPotentiallyHazardousAsteroid;
        }

        [DisplayName("Date")]
        public string Date { get; set; }

        [DisplayName("ID")]
        public long Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Absolute magnitude high")]
        public double AbsoluteMagnitudeH { get; set; }

        [DisplayName("Estimated diameter")]
        public double EstimatedDiameter { get; set; }

        [DisplayName("Potentially hazardous")]
        public bool IsPotentiallyHazardous { get; set; }
    }
}
