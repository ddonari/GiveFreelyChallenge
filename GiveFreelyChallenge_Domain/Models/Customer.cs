﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveFreelyChallenge_Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AffiliateId { get; set; }
    }
}