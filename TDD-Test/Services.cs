using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public Variant[] AssembleVariants(List<string> rows)
        {
            var variants = rows
                .Select(row => row.Split(";"))
                .GroupBy(values => values[1])
                .Select(group =>
                {
                    var gtins = group
                        .Select(values => AssembleGtin(values))
                        .OfType<Gtin>().ToArray();

                    return new Variant
                    {
                        Name = group.Key,
                        Price = FindLowestPrice(gtins), 
                        Gtins = gtins
                    };
                });

            return variants.OfType<Variant>().ToArray();
        }

        public Product AssembleProduct(List<string> rows)
        {
            var productName = rows
                .Select(row => row.Split(";"))
                .Select(values => values[2])
                .Distinct()
                .FirstOrDefault();

            var variants = AssembleVariants(rows);

            return new Product()
            {
                Name = productName,
                Price = FindLowestPrice(variants),
                Variants = variants
            };
        }

        public int FindLowestPrice(ILowerPrice[] items)
        {
            int lowestPrice = int.MaxValue;

            foreach (var item in items)
            {
                if (item.Price < lowestPrice)
                {
                    lowestPrice = item.Price;
                }
            }

            return lowestPrice;
        }

    }
}
