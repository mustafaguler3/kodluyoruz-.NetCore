using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Webapi.DbOperations;

namespace GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public readonly BookStoreDbContext _context;
        public int GenreId { get; set; }
        
        
        public readonly IMapper _mapper;

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle(){
            var genre = _context.Genres.SingleOrDefault(i=>i.Id==GenreId && i.IsActive);
            if (genre is null){
                throw new InvalidOperationException("kitap türü bulunamadı");
            }
            
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    
}
public class GenreDetailViewModel {
    public int Id { get; set; }
    public string Name { get; set; }
    
    
    
    
}
}