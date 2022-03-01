using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DbOperations;

namespace Webapi.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(i=>i.Id==GenreId);
            if(genre is null){
                throw new InvalidOperationException("kitap türü bulunamadı!");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}