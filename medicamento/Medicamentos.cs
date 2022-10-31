using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicamento
{
    class Medicamentos
    {
        public List<Medicamento> listaMedicamentos { get; }
        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }
        public bool deletar(Medicamento medicamento)
        {
            if (medicamento.qtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(medicamento);
                return true;
            }
            return false;
        }
        public Medicamento pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(m => m.Equals(medicamento));
        }
    }
}
