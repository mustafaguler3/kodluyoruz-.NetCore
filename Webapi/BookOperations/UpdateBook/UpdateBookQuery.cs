using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Common;
using Webapi.DbOperations;

namespace Webapi.BookOperations.UpdateBook
{
    public class UpdateBookQuery
    {
        private readonly BookStoreDbContext _DbContext;
        public UpdateBookModel Model;
        public UpdateBookQuery(BookStoreDbContext DbContext){
            _DbContext = DbContext;
        }

        public void Handle(){
            var book = _DbContext.Books.SingleOrDefault(i=>i.Id==Model.Id);

            if(book is null){
                throw new Exception("kitap mevcut degil");
            }
            book.GenreId = Model.Genre;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;
            book.Title = Model.Title;

            _DbContext.Update(book);
            _DbContext.SaveChanges();
        }

    }

    public class UpdateBookModel {
        public int Id {get;set;}
        public string Title {get;set;}
        public int PageCount {get;set;}
        public DateTime PublishDate {get;set;}
        public int Genre {get;set;}
    }
}