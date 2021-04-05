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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesPokemonContext _context;

        public DeleteModel(RazorPagesPokemonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pokemon Pokemon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pokemon = await _context.Pokemon.FirstOrDefaultAsync(m => m.ID == id);

            if (Pokemon == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pokemon = await _context.Pokemon.FindAsync(id);

            if (Pokemon != null)
            {
                _context.Pokemon.Remove(Pokemon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
