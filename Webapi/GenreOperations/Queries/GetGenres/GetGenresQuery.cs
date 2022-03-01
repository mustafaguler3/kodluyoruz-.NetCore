using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Webapi.DbOperations;

namespace GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public int GenreId {get;set;}
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle(){
            var genres = _context.Genres.Where(i=>i.IsActive).OrderBy(i=>i.Id);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }
    public class GenresViewModel {
        public int Id { get; set; }
        public string Name { get; set; }      
        
        
    }
}