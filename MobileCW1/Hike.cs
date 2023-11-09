using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCW1
{
    public class Hike
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public bool ParkingAvailable { get; set; }
        public string Length { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public Hike() {}
        public Hike(int id, string name, string location, DateTime date, bool parkingAvailable, string length, string difficulty, string description)
        {
            Id = id;
            Name = name;
            Location = location;
            Date = date;
            ParkingAvailable = parkingAvailable;
            Length = length;
            Difficulty = difficulty;
            Description = description;
        }
    }
}
