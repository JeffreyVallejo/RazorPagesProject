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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesScoreRate.Data.RazorPagesScoreRateContext _context;

        public IndexModel(RazorPagesScoreRate.Data.RazorPagesScoreRateContext context)
        {
            _context = context;
        }

        public IList<SoundTrack> SoundTrack { get;set; }

        public async Task OnGetAsync()
        {

            // var average = _context.ScoreRate.Where(x => x.AlbumnId == 5).AverageAsync(x => x.Rank);

            // var average = await _context.ScoreRate.AverageAsync(x => x.Rank);
            SoundTrack = await _context.SoundTrack.ToListAsync();
        }
    }
}
