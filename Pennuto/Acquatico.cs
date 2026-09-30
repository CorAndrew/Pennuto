using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pennuto
{
    public class Aquatico : Pennuto
    {
        public string TipoAcqua { get; set; } // dolce o salata

        public Aquatico(string codice, string specie, string habitat, bool migratore, double aperturaAlare, string tipoAcqua)
            : base(codice, specie, habitat, migratore, aperturaAlare)
        {
            TipoAcqua = tipoAcqua;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Categoria: Aquatico | Tipo Acqua: {TipoAcqua}";
        }
    }
}
