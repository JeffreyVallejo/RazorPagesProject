using System;
namespace ScoreScorer.Models
{
    public class RatedSoundtrackToProfile
    {
        public RatedSoundtrackToProfile()
        {
        }

        public int ID { get; set; }
        public string Soundtrack { get; set; }
        public int ProfileId { get; set; }
    }
}
