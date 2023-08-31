using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCase.Codes
{
    class Person
    {
        public string Fornavn { get; }
        public string Efternavn { get; }
        public string Telefonnummer { get; }

        public Person(string fornavn, string efternavn, string telefonnummer)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            Telefonnummer = telefonnummer;
        }
    }
}
