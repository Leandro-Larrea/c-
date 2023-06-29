using System.ComponentModel.DataAnnotations;
namespace pokeSharp.models
{
    public class _Type
    {

        public Guid? TypeId {get; set;}

        public string? Name {get; set;}  

        public string? MoveDamageClass {get; set;}
        public virtual ICollection<Moves> Moves {get; set;}

        public virtual ICollection<Pokemon> Pokemons {get; set;}
    }
}