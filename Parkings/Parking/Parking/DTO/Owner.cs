using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DTO
{
    public class Owner
    {
        public Owner() { }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Name { get; set; }
        public string CitizenId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }
    }
}
