using MongoDB.Bson.Serialization.Attributes;

namespace elosztott_gyak.Model
{
    [BsonIgnoreExtraElements]
    public class Car
    {
        public string LicensePlate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool HasAC { get; set; }

        public Car(string licensePlate, string manufacturer, string model, string color, bool hasAC)
        {
            LicensePlate = licensePlate;
            Manufacturer = manufacturer;
            Model = model;
            Color = color;
            HasAC = hasAC;
        }
    }
}