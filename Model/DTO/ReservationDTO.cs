using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Model.DTO
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set;  }
        public string UserName { get; set; }
        public int FloorNum { get; set; }
        public int RoomNum { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
