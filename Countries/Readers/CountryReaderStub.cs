using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Models;

namespace Countries.Readers
{
    public class CountryReaderStub : ICountryReader
    {
        public IEnumerable<Country> ReadCountriesFromXMLFile()
        {
            return new List<Country>() { new Country() { Name = "Poland", Capital = "Warsaw", Population = 33000000 }, new Country() { Name = "Japan", Capital = "Tokyo", Population = 100000000 } };
        }

        public bool SaveCountriesIntoXMLFile(IEnumerable<Country> countries)
        {
            throw new NotImplementedException();
        }
    }
}
