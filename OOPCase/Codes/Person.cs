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
