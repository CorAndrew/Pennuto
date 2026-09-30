using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pennuto
{
    public class Avvistamento
    {
        public DateTime Data { get; set; }
        public string Luogo { get; set; }
        public string Note { get; set; }

        public Avvistamento(DateTime data, string luogo, string note)
        {
            Data = data;
            Luogo = luogo;
            Note = note;
        }

        public override string ToString()
        {
            return $"Data: {Data.ToShortDateString()} | Luogo: {Luogo} | Note: {Note}";
        }
    }
}
