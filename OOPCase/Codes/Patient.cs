namespace OOPCase.Codes
{
    class Patient : Person
    {
        public List<Læge> TildelteLæger { get; } = new List<Læge>();

        public Patient(string fornavn, string efternavn, string telefonnummer)
            : base(fornavn, efternavn, telefonnummer) { }

        public void TilføjLæge(Læge læge)
        {
            // Check for forbidden læge combinations
            if (TildelteLæger.Exists(l => l.Specialitet == Specialitet.Kirurgi) && læge.Specialitet == Specialitet.Onkologi)
            {
                throw new Exception("Kombinationen af Kirurgi og Onkologi er ikke tilladt.");
            }

            // Check om lægen har allerede 3 eller flere patienter
            if (læge.PatientTildelinger >= 3)
            {
                throw new Exception($"Lægen {læge.Fornavn} {læge.Efternavn} er allerede tildelt til tre eller flere patienter.");
            }

            TildelteLæger.Add(læge);
            læge.TilføjPatient();
        }
    }
}
