using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class FindViewModel
    {
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Area> Areas { get; set; }
    }
}
