using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesPokemon.Models;

namespace RazorPagesPokedex.Pages.PokemonIndex
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesPokemonContext _context;

        public CreateModel(RazorPagesPokemonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pokemon Pokemon { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pokemon.Add(Pokemon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
