using Countries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Providers
{
    public interface ICountryProvider
    {
        IEnumerable<Country> GetCountries();
        bool SaveCountries(IEnumerable<Country> countries);
    }
}
