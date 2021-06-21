using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BookStore
{
    internal class CsvWriter : IWriter<Book>
    {
        private readonly string csvFileName;

        public CsvWriter(string csvFileName)
        {
            this.csvFileName = csvFileName;
        }

        public void Write(List<Book> books)
        {
            using (TextWriter writer = new StreamWriter(@"../../../" + csvFileName + ".csv", false, System.Text.Encoding.UTF8))
            {
                CsvHelper.CsvWriter csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(books);
            }
        }
    }
}