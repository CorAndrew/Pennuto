using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pennuto
{
    public class Canterino : Pennuto
    {
        public string CantoCaratteristico { get; set; }

        public Canterino(string codice, string specie, string habitat, bool migratore, double aperturaAlare, string cantoCaratteristico)
            : base(codice, specie, habitat, migratore, aperturaAlare)
        {
            CantoCaratteristico = cantoCaratteristico;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Categoria: Canterino | Canto: {CantoCaratteristico}";
        }
    }
}
