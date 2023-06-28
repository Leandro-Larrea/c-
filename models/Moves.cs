using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokeSharp.models
{
    public class Moves
    {
        public Guid MoveId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public Guid TypeId { get; set; }
        public virtual _Type Type {get; set; }
    }
}