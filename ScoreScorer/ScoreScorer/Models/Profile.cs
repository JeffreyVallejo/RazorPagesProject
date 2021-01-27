﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreScorer.Models
{
    public class Profile
    {
        public Profile()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string Soundtrack { get; set; }
    }
}
