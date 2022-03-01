using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.DbOperations;

namespace Webapi.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        public readonly BookStoreDbContext _context;

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(i=>i.Id==GenreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }

            if(_context.Genres.Any(i=>i.Name.ToLower()== Model.Name.ToLower()&&i.Id != GenreId)){
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");
            }
            genre.Name = Model.Name.Trim() == default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel {
        public string Name { get; set; }        
        public bool IsActive { get; set; }
        
        
    }
}