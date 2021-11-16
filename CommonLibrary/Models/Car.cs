using System;

namespace CommonLibrary.Models
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public DateTimeOffset ProductionDate { get; set; }
        public override string ToString() => $"{Make,-15}{Model,-8}{ProductionDate:MM/dd/yyyy}";
    }
}