using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DbOperations;

namespace Webapi.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var author = _context.Authors.SingleOrDefault(i=>i.Id==AuthorId);
            if(author is null){
                throw new InvalidOperationException("Silinecek yazar bulunamadı");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }

    
}