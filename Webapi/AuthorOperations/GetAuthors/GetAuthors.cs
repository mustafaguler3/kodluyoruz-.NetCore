using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.AuthorOperations.GetAuthors
{
    public class GetAuthors
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthors(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Author> Handle(){
            var authors = _context.Authors.OrderBy(i=>i.Id).ToList();
            List<AuthorsListModel> vm = new List<AuthorsListModel>();
            foreach(var item in authors){
                vm.Add(new AuthorsListModel(){
                    Name = item.Name,
                    Lastname = item.Lastname,
                    BirthDay = item.BirthDay                    
                });
            }
            return authors;

        }
    }

    public class AuthorsListModel {
        public string Name { get; set; }        
        public string Lastname { get; set; }        
        public DateTime BirthDay { get; set; }
    }
}