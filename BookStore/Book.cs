using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BookStore
{
    [DataContract]
    class Book : IComparable
    {
        [DataMember(Name = "@id")]
        public string Id { get; set; }
        [DataMember(Name = "author")]
        public string Author { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "genre")]
        public string Genre { get; set; }
        [DataMember(Name = "price")]
        public double Price { get; set; }
        [DataMember(Name = "publish_date")]
        public DateTime PublishDate { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }

        public int CompareTo(object otherBook)
        {
            return otherBook is Book book ? Title.CompareTo(book.Title) : -1;
        }

        public override string ToString()
        {
            return $"{Id} {Author} {Title} {Genre} {Price} {PublishDate} {Description}";
        }
    }
}
