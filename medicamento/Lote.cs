using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicamento
{
    class Lote
    {
        public Lote(int id, int qtde, DateTime venc)
        {
            Id = id;
            Qtde = qtde;
            Venc = venc;
        }
        public Lote()
        {
            Id = 0;
            Qtde = 0;
            Venc = new DateTime();
        }
        public int Id { get; set; }
        public int Qtde { get; set; }
        public DateTime Venc { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Qtde} - {Venc.ToString("yyyy/MM/dd HH:mm:ss")}";
        }
    }
}
