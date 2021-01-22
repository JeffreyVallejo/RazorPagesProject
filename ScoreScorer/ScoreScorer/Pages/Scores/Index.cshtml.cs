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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesScoreRateContext _context;

        public IndexModel(RazorPagesScoreRateContext context)
        {
            _context = context;
        }

        public IList<ScoreRate> Scores { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var scores = from m in _context.ScoreRate
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scores = scores.Where(s => s.Name.Contains(SearchString));
            }

            Scores = await scores.ToListAsync();
        }
    }
}
