using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    class BooksManipulation
    {
        // TODO: Move to config
        private readonly string filterAuthorName;
        private readonly DayOfWeek filterDayOfWeek;

        public BooksManipulation(string filterAuthorName, DayOfWeek filterDayOfWeek)
        {
            this.filterAuthorName = filterAuthorName;
            this.filterDayOfWeek = filterDayOfWeek;
        }

        public void Manipulate(List<Book> books)
        {
            books.RemoveAll(item => item.Author.Contains(filterAuthorName) || item.PublishDate.DayOfWeek == filterDayOfWeek);
            books.ForEach(item => item.Price = Math.Ceiling(item.Price));
        }
    }
}
