using System;
using System.IO;

namespace BookStore
{
    class FileSourceReader : ISourceReader
    {
        private readonly string name;

        public FileSourceReader(string name)
        {
            this.name = name;
        }

        public string ReadAllData()
        {
            string result = null;
            try
            {
                result = File.ReadAllText(@"../../../" + name + ".json");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in reading file " + name + ": " + ex);
            }
            return result;
        }
    }
}
