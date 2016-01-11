using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Models;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Countries.Readers
{
    public class CountryReader : ICountryReader
    {
        private readonly string _path;

        public CountryReader(string path)
        {
            _path = path;
        }

        public IEnumerable<Country> ReadCountriesFromXMLFile()
        {
            XDocument doc = XDocument.Parse(File.ReadAllText(_path));
            IEnumerable<Country> result = from item in doc.Descendants("Country")
                                          select new Country()
                                          {
                                              Name = (string)item.Attribute("Name"),
                                              Capital = (string)item.Attribute("Capital"),
                                              Population = (int)item.Attribute("Population")
                                          };
            return result;
        }

        public bool SaveCountriesIntoXMLFile(IEnumerable<Country> countries)
        {
            XDocument doc = new XDocument(new XElement("Countries", 
                countries.Select(x => new XElement("Country", 
                    new XAttribute("Name", x.Name), 
                    new XAttribute("Capital", x.Capital), 
                    new XAttribute("Population", x.Population))
            )));

            try
            {
                doc.Save(_path);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
