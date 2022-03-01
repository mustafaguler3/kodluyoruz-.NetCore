using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DbOperations;

namespace Webapi.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(i=>i.Name == Model.Name);
            if(genre is not null){
                throw new InvalidOperationException("kitap türü zaten mevcut");
            }
            genre = new Entities.Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel {
        public string Name { get; set; }
        
        
    }
}