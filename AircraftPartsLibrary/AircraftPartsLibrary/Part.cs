using System;

namespace AircraftPartsLibrary
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public PartType Type { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PartStatus Status { get; set; }
        public string AircraftId { get; set; }
        public string Description { get; set; }

        public Part()
        {
            Name = "";
            PartNumber = "";
            AircraftId = "";
            Description = "";
            ManufactureDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Name} ({PartNumber}) - {Status}";
        }
    }
}