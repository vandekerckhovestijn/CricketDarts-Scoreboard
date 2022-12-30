﻿using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PlayerGames> PlayerGames { get; set; }
        public bool HasTurn { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int CurrentTotalScore { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
    }
}
