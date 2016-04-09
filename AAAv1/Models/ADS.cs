using System.Collections.Generic;

namespace AAAv1.Models
{
    public class ADS
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Car Car { get; set; }
        public List<PhotoList> PhotoList { get; set; }
    }

    public class Car
    {
        public Model Model { get; set; }
        public string Modification { get; set; }
        public string OdometerState { get; set; } // Пробег
        public string EngineCapacity { get; set; } // Объём
        public string State { get; set; } // Область
        public string Year { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Drivetrain { get; set; } // Привод
        public string Price { get; set; }
    }

    public class Model
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
    }

    public class PhotoList
    {
        public string Filename { get; set; }
        public string Path { get; set; }
    }
}
