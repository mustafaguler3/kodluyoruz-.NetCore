using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DbOperations;

namespace Webapi.BookOperations.GetById
{
    public class GetByIdQuery
    {
        public GetByIdModel Model {get;set;}
        private readonly BookStoreDbContext _DbContext;

        public GetByIdQuery(BookStoreDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public GetByIdModel Handle(){
            var book = _DbContext.Books.Where(i=>i.Id==Model.Id).SingleOrDefault();
            Model.PageCount = book.PageCount;
            Model.PublishDate = book.PublishDate;
            Model.Title = book.Title;
            return Model;
        }
    }

    public class GetByIdModel {

        public int Id {get;set;}
        public string Title {get;set;}
        public int PageCount {get;set;}
        public DateTime PublishDate {get;set;}
        public int Genre {get;set;}

    }
}