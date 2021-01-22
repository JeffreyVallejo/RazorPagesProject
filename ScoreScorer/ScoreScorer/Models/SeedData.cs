using System;
using System.Linq;
using RazorPagesScoreRate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ScoreScorer.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesScoreRateContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesScoreRateContext>>()))
            {
                // Look for any movies.
                if (context.ScoreRate.Any())
                {
                    return;   // DB has been seeded
                }

                context.ScoreRate.AddRange(
                    new ScoreRate
                    {
                        Name = "Titanic Soundtrack",
                        Rank = 7,
                        LikeDescription = "The soundtrack is beautiful.",
                        DislikeDescription = "The soundtracks sounds very 90's."
                    },

                    new ScoreRate
                    {
                        Name = "Interstellar Soundtrack",
                        Rank = 7,
                        LikeDescription = "The soundtrack portrays anxiety and space.",
                        DislikeDescription = "The soundtracks is boring at times."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
