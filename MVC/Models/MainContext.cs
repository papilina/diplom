using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Models
{
    public class MainContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PlaceType> PlaceTypes { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public MainContext(DbContextOptions<MainContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
