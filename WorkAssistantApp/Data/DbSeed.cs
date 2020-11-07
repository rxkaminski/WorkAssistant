using System;
using System.Collections.Generic;
using System.Linq;
using WorkAssistantApp.Data.Models;

namespace WorkAssistantApp.Data
{
    public static class DbSeed
    {
        public static void Seed(WorkAssistantDbContext dbContext)
        {
            CreateUsers(dbContext);
            CreateProjects(dbContext);
            CreateStatusStartHour(dbContext);
            CreateStatusCurrent(dbContext);
            CreateStatusEventType(dbContext);
            CreatEvents(dbContext);
        }

        private static void CreatEvents(WorkAssistantDbContext dbContext)
        {
            if (dbContext.StatusEvents.Any())
                return;

            var p = 0;
            foreach (var user in dbContext.Users)
            {
                var fromDate = new DateTime(2020, 1, 6, 0, 0, 0, DateTimeKind.Utc);
                var toDate = new DateTime(2020, 1, 10, 0, 0, 0, DateTimeKind.Utc);

                foreach (var status in dbContext.StatusEventTypes)
                {
                    dbContext.StatusEvents.Add(
                        new StatusEvent()
                        {
                            From = fromDate,
                            To = toDate,
                            ProjectId = dbContext.Projects.ToArray().ElementAt(p).Id,
                            TypeId = status.Id,
                            UserId = user.Id,
                            Description = $"Status event for {user.LastName} {user.FirstName}: {status.Description}"
                        }
                    );

                    fromDate = fromDate.AddDays(7);
                    toDate = toDate.AddDays(7);
                }
                p++;
            }

            dbContext.SaveChanges();
        }

        private static void CreateStatusEventType(WorkAssistantDbContext dbContext)
        {
            if (dbContext.StatusEventTypes.Any())
                return;

            var statusEventTypes = new List<StatusEventType>()
            {
                new StatusEventType() { Description = "vacation" },
                new StatusEventType() { Description = "sick leave" },
                new StatusEventType() { Description = "home office" },
                new StatusEventType() { Description = "business trip" },
                new StatusEventType() { Description = "delegation" },
                new StatusEventType() { Description = "office" }
            };
            dbContext.StatusEventTypes.AddRange(statusEventTypes);
            dbContext.SaveChanges();
        }

        private static void CreateStatusCurrent(WorkAssistantDbContext dbContext)
        {
            if (dbContext.StatusCurrents.Any())
                return;

            var p = 1;
            foreach (var user in dbContext.Users)
            {
                dbContext.StatusCurrents.Add(
                    new StatusCurrent()
                    {
                        UserId = user.Id,
                        ProjectId = dbContext.Projects.ToArray().ElementAt(p++).Id,
                        StatusDescription = "Status for " + user.LastName + " " + user.FirstName,
                        StartHourOnMondayId = 1,
                        StartHourOnTuesdayId = 1,
                        StartHourOnWednesdayId = 1,
                        StartHourOnThursdayId = 1,
                        StartHourOnFridayId = 1,
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void CreateStatusStartHour(WorkAssistantDbContext dbContext)
        {
            if (dbContext.StatusStartHours.Any())
                return;

            for (var h = 6; h <= 10; h++)
            {
                dbContext.StatusStartHours.AddRange(
                    new StatusStartHour() { Hour = $"{h}:00" },
                    new StatusStartHour() { Hour = $"{h}:30" }
                    );
            }
            dbContext.SaveChanges();
        }

        private static void CreateProjects(WorkAssistantDbContext dbContext)
        {
            if (dbContext.Projects.Any())
                return;

            var projects = new List<Project>();
            projects.Add(new Project()
            {
                Number = "20-0001",
                Title = "Mega projekt 1",
                Start = new DateTime(2020, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc),
                End = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                Description = "Super mega projekt",
                ProjectManagerId = dbContext.Users.ToArray().ElementAt(1).Id,
                CreatedById = dbContext.Users.ToArray().ElementAt(2).Id,
                //CreatedAt = DateTime.UtcNow.AddDays(-10),
                ModifiedById = dbContext.Users.ToArray().ElementAt(3).Id,
                //ModifiedAt = DateTime.UtcNow
            });

            projects.Add(new Project()
            {
                Number = "20-0002",
                Title = "Hiper projekt 2",
                Start = new DateTime(2019, 11, 01, 0, 0, 0, 0, DateTimeKind.Utc),
                End = new DateTime(2019, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                Description = "Opis hiper projektu",
                ProjectManagerId = dbContext.Users.ToArray().ElementAt(3).Id,
                CreatedById = dbContext.Users.ToArray().ElementAt(3).Id,
                //CreatedAt = DateTime.UtcNow.AddDays(-10),
                ModifiedById = dbContext.Users.ToArray().ElementAt(3).Id,
                //ModifiedAt = DateTime.UtcNow
            });


            var usersCount = dbContext.Users.Count();

            for (var i = 3; i < 100; i++)
            {
                projects.Add(new Project()
                {
                    Number = "20-" + i.ToString("0000"),
                    Title = "Projekt " + i,
                    Start = new DateTime(2019, 11, 01, 0, 0, 0, 0, DateTimeKind.Utc),
                    End = new DateTime(2019, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Opis hiper projektu",
                    ProjectManagerId = dbContext.Users.ToArray().ElementAt(i % usersCount).Id,
                    CreatedById = dbContext.Users.ToArray().ElementAt(i % usersCount).Id,
                    //CreatedAt = DateTime.UtcNow.AddDays(-10),
                    ModifiedById = dbContext.Users.ToArray().ElementAt(i % usersCount).Id,
                    //ModifiedAt = DateTime.UtcNow
                });
            }

            for (var i = 100; i < 200; i++)
            {
                projects.Add(new Project()
                {
                    Number = "19-" + i.ToString("0000"),
                    Title = "Projekt rok 2019: " + i,
                    Start = new DateTime(2019, 11, 01, 0, 0, 0, 0, DateTimeKind.Utc),
                    End = new DateTime(2019, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Opis hiper projektu",
                    ProjectManagerId = dbContext.Users.ToArray().ElementAt(i % usersCount).Id,
                    CreatedById = dbContext.Users.ToArray().ElementAt(i % usersCount).Id,
                    //CreatedAt = DateTime.UtcNow.AddDays(-10),
                    ModifiedById = dbContext.Users.ToArray().ElementAt(i % usersCount).Id,
                    //ModifiedAt = DateTime.UtcNow

                });
            }

            dbContext.AddRange(projects);
            dbContext.SaveChanges();
        }

        private static void CreateUsers(WorkAssistantDbContext dbContext)
        {
            if (dbContext.Users.Any())
                return;

            var users = new List<ApplicationUser>();
            users.Add(new ApplicationUser()
            {
                FirstName = "Rafał",
                LastName = "Nowak",
                Email = "rafal.nowak@aitsystems.pl",
                Phone = "+48 123-123-123",
            });

            users.Add(new ApplicationUser()
            {
                FirstName = "Marcin",
                LastName = "Kowalski",
                Email = "marcin.kowalski@aitsystems.pl",
                Phone = "+48 987-987-987",
            });
            users.Add(new ApplicationUser()
            {
                FirstName = "Stefan",
                LastName = "Burczymucha",
                Email = "stafan.burczymucha@aitsystems.pl",
                Phone = "+48 000-111-222",
            });
            users.Add(new ApplicationUser()
            {
                FirstName = "Ania",
                LastName = "Kowalska",
                Email = "anna.kowalska@aitsystems.pl",
                Phone = "+48 111-111-111",
            });
            users.Add(new ApplicationUser()
            {
                FirstName = "Ewelina",
                LastName = "Malinowska",
                Email = "ewelina.malinowska@aitsystems.pl",
                Phone = "+48 222-222-222",
            });
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }
    }
}
