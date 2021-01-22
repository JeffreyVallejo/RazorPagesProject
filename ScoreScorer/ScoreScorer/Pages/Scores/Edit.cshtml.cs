using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesScoreRate.Data;
using ScoreScorer.Models;

namespace ScoreScorer.Pages.Scores
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesScoreRate.Data.RazorPagesScoreRateContext _context;

        public EditModel(RazorPagesScoreRate.Data.RazorPagesScoreRateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScoreRate ScoreRate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScoreRate = await _context.ScoreRate.FirstOrDefaultAsync(m => m.ID == id);

            if (ScoreRate == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScoreRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreRateExists(ScoreRate.ID))
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

        private bool ScoreRateExists(int id)
        {
            return _context.ScoreRate.Any(e => e.ID == id);
        }
    }
}
