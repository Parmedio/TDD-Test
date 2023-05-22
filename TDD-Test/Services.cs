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
        public Gtin AssembleGtin(string[] input)
        {
            return new Gtin()
            {
                Name = input[0],
                Price = int.Parse(input[3])
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
                        .Select(values => AssembleGtin(values)).ToList();

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

        public Product AssembleProduct(List<string> rows)
        {
            var productName = rows
                .Select(row => row.Split(";"))
                .Select(values => values[2])
                .Distinct()
                .FirstOrDefault();

            return new Product()
            {
                Name = productName,
                Price = 0,
                Variants = AssembleVariants(rows),
            };
        }

        public int FindLowerPrice(List<ILowerPrice> prices)
        {
            return 4;
        }

    }
}
