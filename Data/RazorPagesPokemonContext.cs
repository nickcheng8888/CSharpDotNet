using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesPokemon.Models;

    public class RazorPagesPokemonContext : DbContext
    {
        public RazorPagesPokemonContext (DbContextOptions<RazorPagesPokemonContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesPokemon.Models.Pokemon> Pokemon { get; set; }
    }
