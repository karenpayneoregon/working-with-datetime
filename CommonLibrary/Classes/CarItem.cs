using System.Collections.Generic;
using CommonLibrary.Models;

namespace CommonLibrary.Classes
{
    public class CarItem
    {
        public int Id { get; set; }
        public List<Car> List { get; set; }
        public int Count { get; set; }
    }
}