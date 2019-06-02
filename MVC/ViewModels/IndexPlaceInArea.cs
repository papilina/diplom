using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class IndexPlaceInArea
    {
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Area> Areas { get; set; }
        public int AreaId { get; set; }
        public int PlacetypeId { get; set; }
    }
}
