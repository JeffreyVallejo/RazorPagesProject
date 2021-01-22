using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesScoreRate.Data;
using ScoreScorer.Models;

namespace ScoreScorer.Pages.Scores
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesScoreRate.Data.RazorPagesScoreRateContext _context;

        public DetailsModel(RazorPagesScoreRate.Data.RazorPagesScoreRateContext context)
        {
            _context = context;
        }

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
    }
}
