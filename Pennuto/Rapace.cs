using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pennuto
{
    public class Rapace : Pennuto
    {
        public string Dieta { get; set; }

        public Rapace(string codice, string specie, string habitat, bool migratore, double aperturaAlare, string dieta)
            : base(codice, specie, habitat, migratore, aperturaAlare)
        {
            Dieta = dieta;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Categoria: Rapace | Dieta: {Dieta}";
        }
    }
}
