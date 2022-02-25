using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapi.BookOperations.CreateBook;
using Webapi.BookOperations.GetBooks;
using Webapi.BookOperations.GetById;
using Webapi.BookOperations.UpdateBook;
using Webapi.DbOperations;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        //readonyly birdaha değiştirilmesin consructor içinde set edilsin
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context){
            _context = context;
        }
        private static List<Book> BookList = new List<Book>(){
            new Book{
                Id=1,
                Title="Lead Startup",
                GenreId=1,
                PageCount=50,
                PublishDate=new DateTime(2001,6,12)
                },
                new Book{
                Id=2,
                Title="Herland",
                GenreId=2,
                PageCount=55,
                PublishDate=new DateTime(2001,6,12)
                }
        };
        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public Book GetById(int id){
            GetByIdQuery query = new GetByIdQuery(_context);
            query.Model.Id = id;
            
            return query.Handle();
        }

        [HttpGet]
        public Book Get([FromQuery] string id){
            var book = BookList.Where(i=>i.Id==Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
            //var book = BookList.SingleOrDefault(i=>i.Title==newBook.Title);
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (System.Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            //if(book is not null){
                //return BadRequest();
            //}
            //_context.Books.Add(newBook);
            //_context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel model){
            UpdateBookQuery query = new UpdateBookQuery(_context);            
            query.Model = model;
            query.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            var book = BookList.SingleOrDefault(i=>i.Id==id);
            if(book is null){
                return BadRequest();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}