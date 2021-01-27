using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesScoreRate.Data;
using ScoreScorer.Models;

namespace ScoreScorer.Pages.Profiles
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesScoreRate.Data.RazorPagesScoreRateContext _context;

        public IndexModel(RazorPagesScoreRate.Data.RazorPagesScoreRateContext context)
        {
            _context = context;
        }

        public IList<Profile> Profiles { get;set; }
        public IList<RatedSoundtrackToProfile> RatedSoundtracks { get; set; }

        public async Task OnGetAsync()
        {
            Profiles = await _context.Profile.ToListAsync();

            var query =
                from m in _context.RatedSoundtrackToProfile
                select m;

            query = query.Where(q => q.ProfileId.Equals(Profiles[0].ID));

            RatedSoundtracks = await _context.RatedSoundtrackToProfile.ToListAsync();

            foreach (var RatedSoundtrack in RatedSoundtracks) {
                var found = Profiles.FirstOrDefault(x => x.ID.Equals(RatedSoundtrack.ID));

                found.Soundtrack = RatedSoundtrack.Soundtrack;
            }
        }
    }
}
