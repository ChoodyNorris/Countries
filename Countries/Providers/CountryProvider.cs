using System.Collections.Generic;
using Countries.Models;
using Countries.Readers;

namespace Countries.Providers
{
    public class CountryProvider : ICountryProvider
    {
        private readonly ICountryReader _reader;

        public CountryProvider(ICountryReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _reader.ReadCountriesFromXMLFile();
        }

        public bool SaveCountries(IEnumerable<Country> countries)
        {
            return _reader.SaveCountriesIntoXMLFile(countries);
        }
    }
}
