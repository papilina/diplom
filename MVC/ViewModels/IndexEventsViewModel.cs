using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class IndexEventsViewModel
    {
        public IEnumerable<Area> Areas { get; set; }
        public IEnumerable<PlaceType> PlaceTypes { get; set; }
        public bool OpenNow { get; set; }
        public int AreaId { get; set; }
        public int PlacetypeId { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}
