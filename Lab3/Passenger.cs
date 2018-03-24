using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CabinId { get; set; }

        public Passenger()
        {
            DateOfBirth = DateTime.Now;
        }
    }
}
