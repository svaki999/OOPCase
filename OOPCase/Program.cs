using OOPCase.Codes;

namespace OOPCase
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opret en liste til at gemme alle tilmeldte patienter
            List<Patient> tilmeldPatienter = new List<Patient>();

            // Opret læger 
            Læge øjenlæge = new Læge("Peter", "Hansen", "11111111", Specialitet.Øjenlæge);
            Læge radiologi = new Læge("Martin", "Jensen", "22222222", Specialitet.Radiologi);
            Læge kirurgi = new Læge("Thomas", "Olsen", "33333333", Specialitet.Kirurgi);
            Læge onkologi = new Læge("Ole", "Nielsen", "44444444", Specialitet.Onkologi);

            // Opret en liste af læger og tilføj de oprettede læger
            List<Læge> læger = new List<Læge> { øjenlæge, radiologi, kirurgi, onkologi };

            while (true)
            {
                // Indtast patientens oplysninger
                Console.Write("Indtast patientens fornavn: ");
                string fornavn = Console.ReadLine();

                Console.Write("Indtast patientens efternavn: ");
                string efternavn = Console.ReadLine();

                Console.Write("Indtast patientens telefonnummer: ");
                string telefonnummer = Console.ReadLine();

                // Opret en ny patient med de indtastede oplysninger
                Patient patient = new Patient(fornavn, efternavn, telefonnummer);

                while (true)
                {
                    // Vis en liste over læger, som brugeren kan vælge fra
                    Console.WriteLine("Vælg specialiseret læge:");
                    for (int i = 0; i < læger.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {læger[i].Fornavn} {læger[i].Efternavn}, {læger[i].Specialitet}");
                    }

                    Console.Write("Angiv ID for den valgte læge: ");
                    int selectedLægeIndex = int.Parse(Console.ReadLine()) - 1;

                    // Tjek om valget af læge er gyldigt
                    if (selectedLægeIndex < 0 || selectedLægeIndex >= læger.Count)
                    {
                        Console.WriteLine("Ugyldigt valg af læge. Prøv igen.");
                        continue;
                    }

                    Læge selectedLæge = læger[selectedLægeIndex];

                    try
                    {
                        // Tjek om patienten allerede er tildelt denne læge
                        if (!patient.TildelteLæger.Contains(selectedLæge))
                        {
                            // Tjek om lægen allerede har tildelt maksimalt antal patienter
                            if (selectedLæge.PatientTildelinger < 3)
                            {
                                // Tilføj patienten til lægen og udskriv en bekræftelse
                                patient.TilføjLæge(selectedLæge);
                                Console.WriteLine($"Patient {patient.Fornavn} {patient.Efternavn} er tilmeldt lægen {selectedLæge.Fornavn} {selectedLæge.Efternavn}, {selectedLæge.Specialitet}.");
                            }
                            else
                            {
                                Console.WriteLine("Denne læge har allerede tildelt maksimalt antal patienter.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Denne læge er allerede tildelt til patienten.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fejl: {ex.Message}");
                    }

                    // Spørg om brugeren vil tilføje en ekstra læge til denne patient
                    Console.Write("Vil du tilføje en ekstra læge til denne patient? (j/n): ");
                    if (Console.ReadLine().ToLower() != "j")
                    {
                        break; // Gå videre til næste patient
                    }
                }

                // Tilføj patienten til listen over tilmeldte patienter
                tilmeldPatienter.Add(patient);

                // Spørg om brugeren vil tilføje en ny patient
                Console.Write("Vil du tilføje en ny patient? (j/n): ");
                if (Console.ReadLine().ToLower() != "j")
                {
                    Console.Clear();
                    Console.WriteLine("Programmet afsluttes.");
                    break;
                }
                Console.Clear();
            }
        }
    }

}