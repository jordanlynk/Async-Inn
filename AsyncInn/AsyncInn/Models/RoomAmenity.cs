using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenity
    {

        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        public Amenity amenity { get; set; }
        public Room room { get; set; }
    }
}
