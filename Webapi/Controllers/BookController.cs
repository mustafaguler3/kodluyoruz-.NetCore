using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Webapi.BookOperations.CreateBook;
using Webapi.BookOperations.DeleteBook;
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
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            GetByIdModel result;
            
            try
            {
                GetByIdQuery query = new GetByIdQuery(_context,_mapper);
                query.Model.Id = id;
                result = query.Handle();
            }
            catch (System.Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        public Book Get([FromQuery] string id){
            var book = BookList.Where(i=>i.Id==Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
            //var book = BookList.SingleOrDefault(i=>i.Title==newBook.Title);
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                
                ValidationResult result = validator.Validate(command);
                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine("Özellik "+item.PropertyName + "Error Message "+item.ErrorMessage);
                    }
                }
                else
                {
                        command.Handle();
                }
                
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
            query.Model.Id = id;
            query.Model = model;
            query.Handle();
            return Ok();
        }       
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (System.Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}