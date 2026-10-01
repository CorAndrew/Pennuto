using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pennuto
{
    internal class Program
    {
        private static List<Pennuto> archivio = new List<Pennuto>();

        static void Main(string[] args)
        {
            string scelta;

            do
            {
                Console.WriteLine("1. Inserisci un nuovo esemplare");
                Console.WriteLine("2. Visualizza tutti gli esemplari");
                Console.WriteLine("3. Elimina un esemplare tramite codice");
                Console.WriteLine("4. Registra un avvistamento");
                Console.WriteLine("5. Consulta gli avvistamenti di un esemplare");
                Console.WriteLine("6. Cerca esemplari per specie");
                Console.WriteLine("7. Visualizza soltanto gli esemplari migratori");
                Console.WriteLine("8. Mostra statistiche (Conteggio per categoria e avvistamenti)");
                Console.Write("Scegli un'opzione: ");
                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        InserisciEsemplare();
                        break;
                    case "2":
                        VisualizzaEsemplari();
                        break;
                    case "3":
                        EliminaEsemplare();
                        break;
                    case "4":
                        RegistraAvvistamento();
                        break;
                    case "5":
                        ConsultaAvvistamenti();
                        break;
                    case "6":
                        CercaPerSpecie();
                        break;
                    case "7":
                        VisualizzaMigratori();
                        break;
                    case "8":
                        MostraStatistiche();
                        break;
                    case "0":
                        Console.WriteLine("Uscita dal programma...");
                        break;
                    default:
                        Console.WriteLine("Opzione non valida, riprova.");
                        break;
                }

            } while (scelta != "0");
        }

        static void InserisciEsemplare()
        {
            string codice;
            do
            {
                Console.Write("Inserisci codice univoco: ");
                codice = Console.ReadLine();
                if (CercaPerCodice(codice) != null)
                {
                    Console.WriteLine("Codice già esistente!");
                    codice = "";
                }
            } while (string.IsNullOrWhiteSpace(codice));

            Console.Write("Inserisci specie: ");
            string specie = Console.ReadLine();

            Console.Write("Inserisci habitat: ");
            string habitat = Console.ReadLine();

            Console.Write("È migratore? (1 = Sì, 0 = No): ");
            bool migratore = Console.ReadLine() == "1";

            double aperturaAlare;
            Console.Write("Inserisci apertura alare (in cm): ");
            while (!double.TryParse(Console.ReadLine(), out aperturaAlare) || aperturaAlare <= 0)
            {
                Console.Write("Valore non valido. Inserisci un numero positivo: ");
            }

            Console.WriteLine("Seleziona categoria:");
            Console.WriteLine("1. Rapace");
            Console.WriteLine("2. Canterino");
            Console.WriteLine("3. Aquatico");
            string cat = Console.ReadLine();

            if (cat == "1")
            {
                Console.Write("Inserisci dieta (es. Carnivoro, Insettivoro): ");
                string dieta = Console.ReadLine();
                archivio.Add(new Rapace(codice, specie, habitat, migratore, aperturaAlare, dieta));
            }
            else if (cat == "2")
            {
                Console.Write("Inserisci canto caratteristico: ");
                string canto = Console.ReadLine();
                archivio.Add(new Canterino(codice, specie, habitat, migratore, aperturaAlare, canto));
            }
            else if (cat == "3")
            {
                string tipoAcqua;
                do
                {
                    Console.Write("Inserisci tipo acqua (dolce o salata): ");
                    tipoAcqua = Console.ReadLine().ToLower();
                } while (tipoAcqua != "dolce" && tipoAcqua != "salata");

                archivio.Add(new Aquatico(codice, specie, habitat, migratore, aperturaAlare, tipoAcqua));
            }
            else
            {
                Console.WriteLine("Categoria non valida.");
                return;
            }

            Console.WriteLine("Esemplare inserito con successo!");
        }

        static void VisualizzaEsemplari()
        {
            if (archivio.Count == 0)
            {
                Console.WriteLine("Nessun esemplare presente in archivio.");
                return;
            }

            foreach (Pennuto p in archivio)
            {
                Console.WriteLine(p.ToString());
            }
        }

        static void EliminaEsemplare()
        {
            Console.WriteLine("Inserisci il codice dell'esemplare da eliminare: ");
            string codice = Console.ReadLine();

            Pennuto p = CercaPerCodice(codice);
            if (p != null)
            {
                // Rimuovendo l'esemplare dall'archivio si eliminano anche tutti i suoi avvistamenti
                archivio.Remove(p);
                Console.WriteLine("Esemplare e relativi avvistamenti eliminati con successo.");
            }
            else
            {
                Console.WriteLine("Esemplare non trovato.");
            }
        }

        static void RegistraAvvistamento()
        {
            Console.WriteLine("Inserisci il codice dell'esemplare avvistato: ");
            string codice = Console.ReadLine();

            Pennuto p = CercaPerCodice(codice);
            if (p != null)
            {
                DateTime data;
                Console.Write("Inserisci data");
                string dataStr = Console.ReadLine();
                if (!DateTime.TryParse(dataStr, out data))
                {
                    data = DateTime.Now;
                }

                Console.Write("Inserisci luogo: ");
                string luogo = Console.ReadLine();

                Console.Write("Inserisci note: ");
                string note = Console.ReadLine();

                p.AggiungiAvvistamento(data, luogo, note);
                Console.WriteLine("Avvistamento registrato con successo!");
            }
            else
            {
                Console.WriteLine("Esemplare non trovato.");
            }
        }

        static void ConsultaAvvistamenti()
        {
            Console.WriteLine("Inserisci il codice dell'esemplare: ");
            string codice = Console.ReadLine();

            Pennuto p = CercaPerCodice(codice);
            if (p != null)
            {
                List<Avvistamento> avvistamenti = p.GetAvvistamenti();
                Console.WriteLine($"\nAvvistamenti per l'esemplare [{p.Codice}] {p.Specie}:");
                if (avvistamenti.Count == 0)
                {
                    Console.WriteLine("Nessun avvistamento registrato per questo esemplare.");
                }
                else
                {
                    foreach (Avvistamento a in avvistamenti)
                    {
                        Console.WriteLine($"{a}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Esemplare non trovato.");
            }
        }

        static void CercaPerSpecie()
        {
            Console.WriteLine("Inserisci la specie da cercare: ");
            string specie = Console.ReadLine();

            bool trovato = false;
            foreach (Pennuto p in archivio)
            {
                if (p.Specie.Equals(specie, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(p);
                    trovato = true;
                }
            }

            if (!trovato)
            {
                Console.WriteLine("Nessun esemplare trovato per la specie inserita.");
            }
        }

        static void VisualizzaMigratori()
        {
            bool trovato = false;
            foreach (Pennuto p in archivio)
            {
                if (p.Migratore)
                {
                    Console.WriteLine(p);
                    trovato = true;
                }
            }

            if (!trovato)
            {
                Console.WriteLine("Nessun esemplare migratore presente.");
            }
        }

        static void MostraStatistiche()
        {
            int rapaci = 0;
            int canterini = 0;
            int acquatici = 0;
            int totaleAvvistamenti = 0;

            foreach (Pennuto p in archivio)
            {
                if (p is Rapace) rapaci++;
                else if (p is Canterino) canterini++;
                else if (p is Aquatico) acquatici++;

                totaleAvvistamenti += p.GetAvvistamenti().Count;
            }

            Console.WriteLine($"Totale Rapaci: {rapaci}");
            Console.WriteLine($"Totale Canterini: {canterini}");
            Console.WriteLine($"Totale Acquatici: {acquatici}");
            Console.WriteLine($"Totale complessivo esemplari: {archivio.Count}");
            Console.WriteLine($"Totale complessivo avvistamenti: {totaleAvvistamenti}");
        }

        private static Pennuto CercaPerCodice(string codice)
        {
            foreach (Pennuto p in archivio)
            {
                if (p.Codice.Equals(codice, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }
            return null;
        }
    }
}