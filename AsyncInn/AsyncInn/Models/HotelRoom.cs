using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int HotelID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }


        // navigation properties
        public Hotel hotel { get; set; }
        public Room room { get; set; }

    }
}
