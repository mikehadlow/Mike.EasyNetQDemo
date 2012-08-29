using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Mike.EasyNetQDemo
{
    public class WordLoader
    {
        public static IEnumerable<string> LoadWords()
        {
            var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (assemblyLocation == null)
            {
                throw new ApplicationException("Could not retrieve assembly location");
            }

            var path = Path.Combine(assemblyLocation, "Words.txt");
            using(var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }
    }
}