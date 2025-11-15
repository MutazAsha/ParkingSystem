using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ParkingSlot
    {
        public int Id { get; set; }
        public string SlotNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
