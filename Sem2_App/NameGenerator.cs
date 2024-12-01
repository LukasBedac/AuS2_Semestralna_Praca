using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bogus;
namespace Sem2_App
{
    public static class NameGenerator
    {
        private static Faker faker = new Faker("en");
        public static string GenerateSureName()
        {
            return faker.Name.FirstName();           
        }

        public static string GenerateLastName()
        {
            return faker.Name.LastName();
        }
    }
}
