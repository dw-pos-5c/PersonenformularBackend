using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDb
{
    public partial class Adress
    {
        public override string ToString()
        {
            return $"{City?.CountryCode}-{City?.PostalCode} {City?.Name},{StreetName} {StreetNr}";
        }
    }
}
