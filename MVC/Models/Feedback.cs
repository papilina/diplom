using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Place Place { get; set; }
        public int PlaceId { get; set; }
        public DateTime DateFeedback { get; set; }
        public string Text { get; set; }
    }
}
