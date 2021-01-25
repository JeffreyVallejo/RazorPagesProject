using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesScoreRate.Data;
using ScoreScorer.Models;

namespace ScoreScorer.Pages.SoundTracks
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesScoreRate.Data.RazorPagesScoreRateContext _context;

        public DeleteModel(RazorPagesScoreRate.Data.RazorPagesScoreRateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SoundTrack SoundTrack { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SoundTrack = await _context.SoundTrack.FirstOrDefaultAsync(m => m.ID == id);

            if (SoundTrack == null)
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

            SoundTrack = await _context.SoundTrack.FindAsync(id);

            if (SoundTrack != null)
            {
                _context.SoundTrack.Remove(SoundTrack);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
