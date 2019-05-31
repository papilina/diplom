using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Place
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public PlaceType PlaceType { get; set; }
        [Required]
        public int PlaceTypeId { get; set; }
        public string Address { get; set; }
        public Area Area { get; set; }
        [Required]
        public int AreaId { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        [PhoneAttribute]
        public string Phone { get; set; }
    }
}
