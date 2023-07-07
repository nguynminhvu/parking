using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owner.DTO
{
    public class ParkingAccept
    {
        public ParkingAccept() { }
        public Guid Id { get; set; }
        public Guid IdOwner { get; set; }
        public string Name { get; set; }
        public Guid IdLocation { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }

    }
}
