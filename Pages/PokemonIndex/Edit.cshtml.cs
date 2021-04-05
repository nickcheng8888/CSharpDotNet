using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesPokemon.Models;

namespace RazorPagesPokedex.Pages.PokemonIndex
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesPokemonContext _context;

        public EditModel(RazorPagesPokemonContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(Pokemon.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(e => e.ID == id);
        }
    }
}
