using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    namespace pokeSharp.models{
    public class Pokemon
    {        
        public Guid id {get; set;}
        public string? name {get; set;} 
        public string? LastName{get; set;}
        
        public DateTime DateTime{get; set;}

        public List<_Type>? Types {get; set;} 

        [NotMapped]
        public List<Guid>? TypesToReceive{get; set;}

        

    }
}