﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICobranca.Models
{
    public class Debit
    {
        public string CardId { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
    }
}