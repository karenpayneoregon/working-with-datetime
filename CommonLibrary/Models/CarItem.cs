using System.Collections.Generic;

namespace CommonLibrary.Models
{
    public class CarItem
    {
        public int Id { get; set; }
        public List<Car> List { get; set; }
        public int Count { get; set; }
    }
}