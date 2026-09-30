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
                Console.WriteLine("0. Uscire");
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
                    default:
                        Console.WriteLine("Opzione non valida");
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
                    Console.WriteLine("Codice già esistente");
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
            Console.Write("Scelta: ");
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
                Console.WriteLine("Categoria non valida");
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


    }
}
