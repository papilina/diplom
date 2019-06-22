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
        [Required (ErrorMessage = "Не указано название")]
        public string Name { get; set; }
        public PlaceType PlaceType { get; set; }
        [Required (ErrorMessage = "Не указан тип мероприятия")]
        public int PlaceTypeId { get; set; }
        public string Address { get; set; }
        public Area Area { get; set; }
        [Required (ErrorMessage = "Не указан район")]
        public int AreaId { get; set; }
        [EmailAddressAttribute]
        public string Email { get; set; }
        [DataType(DataType.Url)]
        public string Site { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartWork { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndWork { get; set; }
        [PhoneAttribute]
        public string Phone { get; set; }
    }
}
