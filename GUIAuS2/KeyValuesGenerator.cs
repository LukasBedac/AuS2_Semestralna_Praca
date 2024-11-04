using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GUIAuS2
{
    public static class KeyValuesGenerator
    {
        private const int STRINGLENGTH = 6;
        private static Random rand = new Random();
        private static List<char> chars = new List<char>();

        static KeyValuesGenerator()
        {
            Init();
        }

        public static string GetStringKey()
        {
            string key = string.Empty;
            for (int i = 0; i < STRINGLENGTH; i++) 
            {
                key += chars[rand.Next(chars.Count)];
            }
            return key;
        }
        public static int GetIntKey() 
        {
            return rand.Next();
        }

        private static void Init()
        {
            // Add uppercase letters
            for (char c = 'A'; c <= 'Z'; c++)
            {
                chars.Add(c);
            }

            // Add lowercase letters
            for (char c = 'a'; c <= 'z'; c++)
            {
                chars.Add(c);
            }
        }
    }
}
