using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPokemon.Models;

namespace RazorPagesPokedex.Pages.PokemonIndex
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesPokemonContext _context;

        public IndexModel(RazorPagesPokemonContext context)
        {
            _context = context;
        }

        public IList<Pokemon> Pokemon { get;set; }

        public async Task OnGetAsync()
        {
            Pokemon = await _context.Pokemon.ToListAsync();
        }
    }
}
