using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Entities
{
    public class Author
    {
        public int Id {get;set;}
        public string Name { get; set; }        
        public string Lastname { get; set; }        
        public DateTime BirthDay { get; set; }
        
        
    }
}