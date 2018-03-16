using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data
{
    class MainTestClass
    {
        static void Main(string[] args)
        {
            string password = "bbahieda";
            Console.WriteLine(Hash("iscae" + password));
        }
        private static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}
