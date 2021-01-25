using System;
using System.Collections.Generic;

namespace ScoreScorer.Models
{
    public class User
    {
        public User()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> RatedSoundtracks { get; set; }
    }
}
