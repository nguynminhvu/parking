using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owner.DTO
{
  public  class ParkingAcceptDetail
    {
        public ParkingAcceptDetail() { }
        public Guid Id { get;set; }
        public Guid IdParking { get;set; }
        public Guid Type { get;set; }
        public double Price { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }

    }
}
