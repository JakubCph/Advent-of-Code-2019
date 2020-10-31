using System;
using System.IO;

namespace Solution
{
    public class Reader
    {
        public static StreamReader OpenStream(string argPath)
        {
            StreamReader file;
            try
            {
                file = new StreamReader(argPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file does not exists on the disc.");
                throw;
            }

            return file;
        }
    }
}