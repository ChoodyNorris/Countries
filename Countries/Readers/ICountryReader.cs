using Countries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Readers
{
    public interface ICountryReader
    {
        IEnumerable<Country> ReadCountriesFromXMLFile();
        bool SaveCountriesIntoXMLFile(IEnumerable<Country> countries);
    }
}
