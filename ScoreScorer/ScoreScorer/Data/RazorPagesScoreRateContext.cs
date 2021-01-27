using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreScorer.Models;

namespace RazorPagesScoreRate.Data
{
    public class RazorPagesScoreRateContext : DbContext
    {
        public RazorPagesScoreRateContext (DbContextOptions<RazorPagesScoreRateContext> options)
            : base(options)
        {
        }

        public DbSet<ScoreScorer.Models.ScoreRate> ScoreRate { get; set; }

        public DbSet<ScoreScorer.Models.SoundTrack> SoundTrack { get; set; }

        public DbSet<ScoreScorer.Models.Profile> Profile { get; set; }

        public DbSet<ScoreScorer.Models.RatedSoundtrackToProfile> RatedSoundtrackToProfile { get; set; }

    }
}
