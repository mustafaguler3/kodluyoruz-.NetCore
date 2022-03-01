using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webapi.Entities;

namespace Webapi.DbOperations
{
    public class DataGenerator
    {
        public static void Initiliaze(IServiceProvider provider){
            using(var context = new BookStoreDbContext(provider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())){
                if(context.Books.Any()){
                    return;
                }
                context.Authors.AddRange(
                    new Author{
                        Name="Mustafa",
                        Lastname="Güler",
                        BirthDay=new DateTime(2001,6,12)},
                    new Author{
                        Name="Hasan",
                        Lastname="Güler",
                        BirthDay=new DateTime(2002,6,14)}
                );
                context.Genres.AddRange(
                    new Genre{Name="Personel Growth"},
                    new Genre{Name="Science Fiction"}
                );
                context.Books.AddRange(
                    new Book{
                Id=1,
                Title="Lead Startup",
                GenreId=1,
                PageCount=50,
                PublishDate=new DateTime(2001,6,12)
                },
                new Book{
                Id=2,
                Title="Herland",
                GenreId=2,
                PageCount=55,
                PublishDate=new DateTime(2001,6,12)
                }
                );
            }
        }
    }
}