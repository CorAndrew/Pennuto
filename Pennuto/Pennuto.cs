using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pennuto
{
    public class Pennuto
    {
        public string Codice { get; set; }
        public string Specie { get; set; }
        public string Habitat { get; set; }
        public bool Migratore { get; set; }
        public double AperturaAlare { get; set; }

        // Composizione: gli avvistamenti appartengono a questo specifico esemplare
        private List<Avvistamento> avvistamenti;

        public Pennuto(string codice, string specie, string habitat, bool migratore, double aperturaAlare)
        {
            Codice = codice;
            Specie = specie;
            Habitat = habitat;
            Migratore = migratore;
            AperturaAlare = aperturaAlare;
            avvistamenti = new List<Avvistamento>();
        }

        public void AggiungiAvvistamento(DateTime data, string luogo, string note)
        {
            Avvistamento nuovoAvvistamento = new Avvistamento(data, luogo, note);
            avvistamenti.Add(nuovoAvvistamento);
        }

        public List<Avvistamento> GetAvvistamenti()
        {
            return avvistamenti;
        }

        public override string ToString()
        {
            string eMigratore = Migratore ? "Sì" : "No";
            return $"[Codice: {Codice}] Specie: {Specie} | Habitat: {Habitat} | Migratore: {eMigratore} | Apertura Alare: {AperturaAlare} cm";
        }
    }
}
