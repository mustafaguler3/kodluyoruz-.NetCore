using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DbOperations;

namespace Webapi.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public UpdateAuthorModel Model;

        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var author = _context.Authors.SingleOrDefault(i=>i.Id==Model.Id);
            if(author is null){
                throw new InvalidOperationException("Yazar zaten mevcut");
            }
            author.Name = Model.Name;
            author.Lastname = Model.Lastname;
            author.BirthDay = Model.BirthDay;

            _context.Update(author);
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Lastname { get; set; }        
        public DateTime BirthDay { get; set; }
    }
}