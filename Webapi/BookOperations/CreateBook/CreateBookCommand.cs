using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DbOperations;

namespace Webapi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _DbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext DbContext,IMapper mapper)
        {
            _DbContext = DbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _DbContext.Books.SingleOrDefault(i => i.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            book = _mapper.Map<Book>(Model); //new Book();
            //book.Title = Model.Title;
            //book.PublishDate = Model.PublishDate;
            //book.PageCount = Model.PageCount;
            //book.GenreId = Model.GenreId;

            _DbContext.Books.Add(book);
            _DbContext.SaveChanges();
        }
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}