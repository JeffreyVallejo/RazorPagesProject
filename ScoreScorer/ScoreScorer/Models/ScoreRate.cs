using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreScorer.Models
{
    public class ScoreRate
    {
        public ScoreRate()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        [Display(Name = "What I Like")]
        public string LikeDescription { get; set; }
        [Display(Name = "What I Dislike")]
        public string DislikeDescription { get; set; }
    }
}
