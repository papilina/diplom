using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }
    }
}
