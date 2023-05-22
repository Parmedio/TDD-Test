using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Test.models
{
    public class Variant : ILowerPrice
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Gtin> Gtins { get; set; }
    }
}
