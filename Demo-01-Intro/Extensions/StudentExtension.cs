using Data.Models;

namespace Demo_01_Intro.Extensions
{
    public static class StudentExtension
    {
        public static string SayHello(this Student s) {
            return $"Bonjour de {s.Firstname}";
        }
    }
}
