﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FWAStatsWeb.Models.ClanViewModels
{
    public class DetailsViewModel
    {
        public bool InAlliance { get; set; }
        public ClanValidity Validity { get; set; }
        public Clan Clan { get; set; }
        public ICollection<ClanDetailsEvent> Events { get; set; }
        public HashSet<string> WarsWithDetails { get; set; }
    }
}
