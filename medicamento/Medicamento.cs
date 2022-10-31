using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Medicamento
{
    class Medicamento
    {
        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
            FilaLotes = new Queue<Lote>();
        }
        public Medicamento()
        {
            Id = 0;
            Nome = "";
            Laboratorio = "";
            FilaLotes = new Queue<Lote>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio{ get; set; }
        public Queue<Lote> FilaLotes { get; }

        public int qtdeDisponivel()
        {
            int total = 0;
            foreach (Lote l in FilaLotes)
            {
                total = total + l.Qtde;
                   
            }
            return total;
        }
        public void comprar(Lote lote)
        {
            FilaLotes.Enqueue(lote);
        }
        public bool vender(int qtde)
        {
            bool podevender = false;

            if (qtde <= qtdeDisponivel())
            {
                podevender = true;

                FilaLotes.Dequeue();
            } 
            return podevender;
        }
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Laboratorio}";
        }
        public override bool Equals(object obj)
        {
            return this.Id.Equals(((Medicamento)obj).Id);
        }
    }
}
