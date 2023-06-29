using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    namespace pokeSharp.models{
    public class Pokemon
    {        
        public int? id {get; set;}
        public string? name {get; set;} 
        public string? LastName{get; set;}
        
        public DateTime DateTime{get; set;}

        [NotMapped]
        public List<Guid> TypesToReceive{get; set;}

        public virtual ICollection<_Type>? Types {get; set;} 

    }
}