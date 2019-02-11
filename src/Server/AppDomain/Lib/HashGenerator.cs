using System;

namespace AppDomain.Lib
{
    public static class HashGenerator
    {
        private static readonly char[] LowercaseLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] Numbers = "0123456789".ToCharArray();

        private static readonly char[][] Items = new[]
        {
            LowercaseLetters,
            UppercaseLetters,
            Numbers
        };
        
        public static string NewHash(int hashLength)
        {
            var random = new Random();
            var resultHash = "";

            for (var i = 0; i < hashLength; i++)
                resultHash += PickChar(random);

            return resultHash;
        }

        private static char PickChar(Random ran)
        {
            var catId = ran.Next(Items.Length);
            var category = Items[catId];

            var elemId = ran.Next(category.Length);
            return category[elemId];
        }
    }
}