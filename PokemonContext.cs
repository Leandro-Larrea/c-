
using System.Timers;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pokeSharp.models;

namespace pokeSharp
{
    public class PokemonContext : DbContext
    {
        [Key]
        public DbSet<Pokemon> Pokemons {get; set;}
        public DbSet<_Type> Types {get; set;}

        public PokemonContext(DbContextOptions<PokemonContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Pokemon> pokemonInitData = new();
            

            modelBuilder.Entity<Pokemon>(pokemon=>
            {
                pokemon.ToTable("Pokemon");
                pokemon.HasKey(c=> c.id );

                pokemon.Property(c=>c.name).IsRequired().HasMaxLength(150);
                pokemon.Property(c=>c.DateTime);
                pokemon.Property(c=>c.LastName);
                

            });
            modelBuilder.Entity<_Type>(tipito=>
            {
                tipito.ToTable("Type");
                tipito.HasKey(tipito=>tipito.TypeId);

                tipito.Property(p => p.Name).IsRequired().HasMaxLength(150);
                tipito.Property(p => p.MoveDamageClass).IsRequired().HasMaxLength(100);
              
         
            });

            modelBuilder.Entity<Moves>(m =>
            {
                m.ToTable("Move");
                m.HasKey(m => m.MoveId);

                m.Property(m=>m.Name).IsRequired().HasMaxLength(150);
                m.Property(m=>m.Url).IsRequired();
                m.HasOne(m=> m.Type).WithMany(p => p.Moves).HasForeignKey(p => p.TypeId);
            });
        }
    }
}