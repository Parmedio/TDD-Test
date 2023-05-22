﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Test.models
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Variant> Variants { get; set; }
    }
}