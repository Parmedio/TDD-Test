using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Test.models;

namespace TDD_Test
{
    public class Services
    {
        public Gtin AssembleGtin(string input)
        {
            string[] splittedInpuString = input.Split(";");

            return new Gtin()
            {
                Name = splittedInpuString[0],
                Price = int.Parse(splittedInpuString[3])
            };
        }

        public List<Variant> AssembleVariants(List<string> rows)
        {
            var variants = rows
                .Select(row => row.Split(";"))
                .GroupBy(values => values[1])
                .Select(group =>
                {
                    var gtins = group
                        .Select(values => AssembleGtin(string.Join(";", values))).ToList();

                    return new Variant
                    {
                        Name = group.Key,
                        Price = 0,
                        Gtins = gtins
                    };
                })
                .ToList();

            return variants;
        }
    }
}
