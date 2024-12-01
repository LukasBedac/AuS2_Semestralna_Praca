using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
namespace Sem2_App
{
    public static class ECVGenerator
    {
        private static Faker faker = new Faker("sk");
        private static Random randChar = new Random();
        private static Random randInt = new Random();
        public static string GetECV()
        {
            StringBuilder ECV = new();
            ECV.Append("AA");
            ECV.Append(randInt.Next(0, 9));
            ECV.Append(randInt.Next(0, 9));
            ECV.Append(randInt.Next(0, 9));
            ECV.Append(faker.Random.Char('A', 'Z'));
            ECV.Append(faker.Random.Char('A', 'Z'));
            return ECV.ToString();
        }
    }
}
