using System;
using System.Collections.Generic;
using System.Configuration;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFileName = ConfigurationManager.AppSettings.Get("InputFileName");
            string csvFileName = ConfigurationManager.AppSettings.Get("OutputFileName");
            string[] nestedJsonKeys = ConfigurationManager.AppSettings.Get("ReaderNested").Split(" ");
            string filterAuthorName = ConfigurationManager.AppSettings.Get("AuthorNameFilter");
            DayOfWeek filterDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), ConfigurationManager.AppSettings.Get("DayOfWeekFilter"));

            IReader<Book> reader = new JsonReader(new FileSourceReader(jsonFileName), nestedJsonKeys);
            List<Book> books = reader.Read();

            if (books != null)
            {
                BooksManipulation manipulation = new BooksManipulation(filterAuthorName, filterDayOfWeek);
                manipulation.Manipulate(books);

                books.Sort();

                IWriter<Book> writer = new CsvWriter(csvFileName);
                writer.Write(books);
            }
        }
    }
}
