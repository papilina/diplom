using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC
{
    public class SampleData
    {
        public static void Initialize(MainContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                 new User
                 {
                     Login = "test",
                     Password = "Xaej5liM",
                     Name = "test",
                     Email = "test@yandex.ru"
                 }
                );
                context.SaveChanges();
            }
            if (!context.PlaceTypes.Any())
            {
                context.PlaceTypes.AddRange(
                new PlaceType
                {
                    Name = "Кинотеатр"
                }    
                );
                context.SaveChanges();
            }

            if (!context.Areas.Any())
            {
                context.Areas.AddRange(
                new Area
                {
                    Name = "Коминтерновский"
                }
                );
                context.SaveChanges();
            }

            if (!context.Places.Any())
            {
                context.Places.AddRange(
                new Place
                {
                    Name = "Парк Победы",
                    PlaceType = context.PlaceTypes.First(),
                    Address = "Проспект Нариманова",
                    Area = context.Areas.First(),
                    Email = "admin@pp.ru",
                    Site = "pp.ru"
                }
                );
                context.SaveChanges();
            }

            if (!context.Evaluations.Any())
            {
                context.Evaluations.AddRange(
                new Evaluation
                {
                    User = context.Users.First(),
                    Place = context.Places.First(),
                    Value = 5
                }
                );
                context.SaveChanges();
            }

            if (!context.Feedbacks.Any())
            {
                context.Feedbacks.AddRange(
                new Feedback
                {
                    User = context.Users.First(),
                    Place = context.Places.First(),
                    Text = "Красивое место",
                    DateFeedback = DateTime.UtcNow
                }
                );
                context.SaveChanges();
            }

            if (!context.Visits.Any())
            {
                context.Visits.AddRange(
                new Visit
                {
                    User = context.Users.First(),
                    Place = context.Places.First(),
                    DateVisit = DateTime.UtcNow
                }
                );
                context.SaveChanges();
            }
        }
       
    }
}
