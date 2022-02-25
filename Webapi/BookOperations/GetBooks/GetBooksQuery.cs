using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Common;
using Webapi.DbOperations;

namespace Webapi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext){
            _dbContext = dbContext;   
        }

        public List<Book> Handle(){
            var bookList = _dbContext.Books.OrderBy(i=>i.Id).ToList();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach(var item in bookList){
                vm.Add(new BooksViewModel(){
                    Title = item.Title,
                    Genre = ((GenreEnum)item.GenreId).ToString(),
                    PublishDate = item.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = item.PageCount
                    
                });
            }
            return bookList;
        }
    }

    public class BooksViewModel {
        public string Title {get;set;}
        public int PageCount {get;set;}
        public string PublishDate {get;set;}
        public string Genre {get;set;}
    }
}