using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model;
        private readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var author = _context.Authors.SingleOrDefault(i => i.Name == Model.Name);
            if (author is not null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }
            author = _mapper.Map<Author>(Model); //new Author();

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

    }
    public class CreateAuthorModel {
        public string Name { get; set; }     
        public string Lastname { get; set; }
        public DateTime BirthDay { get; set; }
    }
}