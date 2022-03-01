using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webapi.Entities;

namespace Webapi.DbOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books {get;set;}
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors {get;set;}
        
    }
}