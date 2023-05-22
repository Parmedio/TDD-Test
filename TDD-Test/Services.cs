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
        public Gtin AssembleGitin(string input)
        {
            string[] splittedInpuString = input.Split(";");

            return new Gtin()
            {
                Name = splittedInpuString[0],
                Price = int.Parse(splittedInpuString[3])
            };
        }

        public Variant AssembleVariant(string row)
        {
            var gtins = row.Select(input =>
            {
                var values = input.Split(";");
                return new Gtin
                {
                    Name = values[0],
                    Price = int.Parse(values[3])
                };
            }).ToList();

            return new Variant()
            {
                Name = input.Split(";")[0],
                Price = int.Parse(input.Split(";")[3])
                Gtins = input()
            };
        }
    }
}
