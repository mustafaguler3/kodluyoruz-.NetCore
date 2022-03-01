using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Webapi.AuthorOperations.CreateAuthor;
using Webapi.AuthorOperations.DeleteAuthor;
using Webapi.AuthorOperations.GetAuthors;
using Webapi.AuthorOperations.UpdateAuthor;
using Webapi.DbOperations;

namespace Webapi.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult GetAuthors(){
            GetAuthors getAuthors = new GetAuthors(_context,_mapper);
            var result = getAuthors.Handle();
            return Ok(result);
        }

        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id){
            try
            {
                DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
                command.AuthorId = id;
                command.Handle();
            }
            catch (System.Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel model){
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model.Id = id;
            command.Model = model;
            command.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor){

            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            
            try
            {
                command.Model = newAuthor;
                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
                //ValidationResult result = validator.Validate(command);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}