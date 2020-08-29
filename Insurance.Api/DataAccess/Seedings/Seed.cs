﻿using DataAccess.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        }
    }
}
