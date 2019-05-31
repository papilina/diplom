using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Place Place { get; set; }
        public int PlaceId { get; set; }
        [Required]
        [Range(1, 5)]
        public int Value { get; set; }
    }
}