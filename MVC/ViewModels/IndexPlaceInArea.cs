using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class IndexPlaceInArea
    {
        public int Id { get; set; }
        public IEnumerable<Place> Places { get; set; }
        public Area Area { get; set; }
    }
}
