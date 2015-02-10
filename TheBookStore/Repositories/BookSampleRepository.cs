using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{
    public class BookSampleRepository : IBookRepository
    {
        List<Book> books;

        public BookSampleRepository()
        {
            var authors = new List<Author>
            {
                new Author{ Id = 1, Name = "Scott", Surname = "Russell" },
                new Author{ Id = 2, Name = "Elsie", Surname = "Hart" },
                new Author{ Id = 3, Name = "Sophia", Surname = "Nakajima" },
            };

            books = new List<Book>
            {
                new Book { Id = 1, Title = "Wedding Bells", Authors = new List<Author>{authors[0]}},
                new Book { Id = 2, Title = "The Truth about Crickets", Authors = new List<Author>{authors[0]}},
                new Book { Id = 3, Title = "The Fine Art of Italian Cooking", Authors = new List<Author>{authors[1], authors[2]}},
                new Book { Id = 4, Title = "Another Day in Europe", Authors = new List<Author>{authors[1]}},
                new Book { Id = 5, Title = "SQL for Beginners", Authors = new List<Author>{authors[2]}},
            };
        }

        public IQueryable<Book> All
        {
            get { return books.AsQueryable(); }
        }

        public IQueryable<Book> Search(string criteria)
        {
            return books.Where(b => b.Title.ToLower().Contains(criteria.ToLower()) ||
                (b.Description != null && b.Description.Contains(criteria)) ||
                (b.ISBN != null && b.ISBN.Contains(criteria))).AsQueryable();
        }

        public Book GetOne(int Id)
        {
            return books.SingleOrDefault(b => b.Id == Id);
        }

        public Book Add(Book book)
        {
            books.Add(book);
            return books[books.Count];  //not minus one?
        }
    }
}