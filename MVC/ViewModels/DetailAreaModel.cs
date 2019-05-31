using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class DetailAreaModel
    {
        public Area Area { get; set; }
        public IEnumerable<PlaceType> PlaceTypes { get; set; }
      
    }
}
