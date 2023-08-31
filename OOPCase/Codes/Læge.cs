using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCase.Codes
{
    class Læge : Person
    {
        public Specialitet Specialitet { get; }

        public int PatientTildelinger { get; private set; }

        public Læge(string fornavn, string efternavn, string telefonnummer, Specialitet specialitet)
            : base(fornavn, efternavn, telefonnummer)
        {
            Specialitet = specialitet;
        }

        public void TilføjPatient()
        {
            PatientTildelinger++;
        }
    }
}
