﻿using System;
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
                     UserName = "admin",
                     Password = "Xaej5liM!",
                     Email = "admin@test.ru",
                     NormalizedEmail = "ADMIN@TEST.RU",
                     PasswordHash = "AQAAAAEAACcQAAAAELuO5Yryhq4eYDZaq7tlWUKg4nNjvNvyyriw0oduR+6Ykbvn/BzCXsIUZ68THaG09w==",
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
                },
                new PlaceType
                {
                    Name = "Парк"
                },
                new PlaceType
                {
                    Name = "Кафе"
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
                },
                new Area
                {
                    Name = "Центральный"
                },
                new Area
                {
                    Name = "Советский"
                },
                new Area
                {
                    Name = "Левобережный"
                },
                new Area
                {
                    Name = "Железнодорожный"
                },
                new Area
                {
                    Name = "Ленинский"
                }
                );
                context.SaveChanges();
            }

            if (!context.Places.Any())
            {
                context.Places.AddRange(
                new Place
                {
                    Name = "Максимир",
                    PlaceType = context.PlaceTypes.Single(s => s.Name == "Кинотеатр"),
                    Address = "Ленинский проспект, 174",
                    Area = context.Areas.Single(s => s.Name == "Железнодорожный"),
                    Email = "admin@maxi-mir.ru",
                    Site = "http://maxi-mir.ru",
                    StartWork = new DateTime(2019, 06, 10, 08, 00, 00),
                    EndWork = new DateTime(2019, 06, 10, 23, 00, 00),
                    Phone = "233‑37-77"
                },
                new Place
                {
                    Name = "Спартак",
                    PlaceType = context.PlaceTypes.Single(s => s.Name == "Кинотеатр"),
                    Address = "Площадь Ленина, 13",
                    Area = context.Areas.Single(s => s.Name == "Центральный"),
                    Site = "http://kinospartak.ru",
                    StartWork = new DateTime(2019, 06, 10, 07, 00, 00),
                    EndWork = new DateTime(2019, 06, 10, 23, 30, 00),
                    Phone = "239‑03-50"
                },
                new Place
                {
                    Name = "Алые паруса",
                    PlaceType = context.PlaceTypes.Single(s => s.Name == "Парк"),
                    Address = "Арзамасская, 4А",
                    Area = context.Areas.Single(s => s.Name == "Левобережный"),
                },
                new Place
                {
                    Name = "Пролетарий",
                    PlaceType = context.PlaceTypes.Single(s => s.Name == "Кинотеатр"),
                    Address = "Проспект Революции, 56",
                    Area = context.Areas.Single(s => s.Name == "Центральный"),
                    Site = "http://proletka.ru",
                    StartWork = new DateTime(2019, 06, 10, 07, 30, 00),
                    EndWork = new DateTime(2019, 06, 10, 23, 30, 00),
                    Phone = "255‑15-51"
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
