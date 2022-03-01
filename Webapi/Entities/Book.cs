using System;
using System.ComponentModel.DataAnnotations.Schema;
using Webapi.Entities;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get;set;}
    public string Title {get;set;}
    public int GenreId {get;set;}
    public int PageCount {get;set;}
    public DateTime PublishDate {get;set;}
    public Author Author {get;set;}
    
}
