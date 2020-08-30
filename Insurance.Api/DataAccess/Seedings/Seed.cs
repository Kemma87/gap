using DataAccess.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess.Seedings
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Countries.Any())
            {
                var countryData = File.ReadAllText("../DataAccess/Seedings/Countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);

                foreach (var country in countries)
                {
                    context.Countries.Add(country);
                }
                context.SaveChanges();
            }

            if (!context.CoverTypes.Any())
            {
                var coverTypeData = File.ReadAllText("../DataAccess/Seedings/CoverType.json");
                var types = JsonConvert.DeserializeObject<List<CoverType>>(coverTypeData);

                foreach (var type in types)
                {
                    context.CoverTypes.Add(type);
                }
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                var rolesData = File.ReadAllText("../DataAccess/Seedings/Roles.json");
                var roles = JsonConvert.DeserializeObject<List<Role>>(rolesData);

                foreach (var role in roles)
                {
                    context.Roles.Add(role);
                }
                context.SaveChanges();
            }

            if (!context.RiskTypes.Any())
            {
                var risksData = File.ReadAllText("../DataAccess/Seedings/RiskType.json");
                var risks = JsonConvert.DeserializeObject<List<RiskType>>(risksData);

                foreach (var risk in risks)
                {
                    context.RiskTypes.Add(risk);
                }
                context.SaveChanges();
            }

            if (!context.Genders.Any())
            {
                var genderData = File.ReadAllText("../DataAccess/Seedings/Genders.json");
                var genders = JsonConvert.DeserializeObject<List<Gender>>(genderData);

                foreach (var gender in genders)
                {
                    context.Genders.Add(gender);
                }
                context.SaveChanges();
            }

            if (!context.Locations.Any())
            {
                var locationData = File.ReadAllText("../DataAccess/Seedings/Locations.json");
                var locations = JsonConvert.DeserializeObject<List<Location>>(locationData);

                foreach (var location in locations)
                {
                    context.Locations.Add(location);
                }
                context.SaveChanges();
            }

            if (!context.Person.Any())
            {
                var personData = File.ReadAllText("../DataAccess/Seedings/Person.json");
                var persons = JsonConvert.DeserializeObject<List<Person>>(personData);

                foreach (var person in persons)
                {
                    person.CountryId = context.Countries.FirstOrDefault().Id;
                    person.GenderId = context.Genders.FirstOrDefault(x => x.Name == "Male").Id;
                    context.Person.Add(person);
                }
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var userData = File.ReadAllText("../DataAccess/Seedings/User.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                foreach (var user in users)
                {
                    GeneratePasswordHash(user, "admin");
                    user.Username = user.Username.ToLower();
                    user.PersonId = context.Person.FirstOrDefault().Id;

                    context.Users.Add(user);
                    context.SaveChanges();

                    var userRoles = new UserRoles
                    {
                        RoleId = context.Roles.FirstOrDefault(x => x.RoleName == "Administrator").Id,
                        UserId = user.Id
                    };

                    context.UserRoles.Add(userRoles);
                }

                context.SaveChanges();
            }
        }

        private static void GeneratePasswordHash(User user, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            };
        }
    }
}
