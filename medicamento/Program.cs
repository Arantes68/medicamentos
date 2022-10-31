using System;

namespace Medicamento
{
    class Program
    {
        public static void Main(string[] args)
        {
            int opcao = 1;
            Medicamentos medicamentos = new Medicamentos();

            while (opcao != 0)
            {
                Console.WriteLine("0. Sair\n1. Cadastrar medicamento" +
                    "\n2. Consultar medicamento (sintético: informar dados1) " +
                    "\n3. Consultar medicamento (analítico: informar dados1 + lotes2)" +
                    "\n4. Comprar medicamento (cadastrar lote)" +
                    "\n5. Vender medicamento (abater do lote mais antigo)" +
                    "\n6. Listar medicamentos (informando dados sintéticos)\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 0:
                        sair();
                        break;
                    case 1:
                        adicionar(medicamentos);
                        break;
                    case 2:
                        consultar1(medicamentos);
                        break;
                    case 3:
                        consultar2(medicamentos);
                        break;
                    case 4:
                        comprar(medicamentos);
                        break;
                    case 5:
                        vender(medicamentos);
                        break;
                    case 6:
                        mostar(medicamentos);
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 9\n\n");
                        break;
                }
            }
        }
        private static void sair()
        {
            Console.ReadKey();
        }
        private static void adicionar(Medicamentos medicamentos)
        {
            Medicamento m = new Medicamento();

            Console.Write("Digite o id: ");
            m.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome: ");
            m.Nome = Console.ReadLine();

            Console.Write("Lab: ");
            m.Laboratorio = Console.ReadLine();

            medicamentos.adicionar(m);
        }

        private static void consultar1(Medicamentos medicamentos)
        {
            Medicamento m = new Medicamento();

            Console.Write("Digite o id: ");
            m.Id = int.Parse(Console.ReadLine());
            m = medicamentos.pesquisar(m);
            if (m == null)
            {
                Console.WriteLine("Não encontrado!");
            }
            else
            {
                Console.WriteLine(m.ToString());               
            }
        }

        private static void consultar2(Medicamentos medicamentos)
        {
            Medicamento m = new Medicamento();

            Console.Write("Digite o id: ");
            m.Id = int.Parse(Console.ReadLine());

            m = medicamentos.pesquisar(m);
            if (m == null)
            {
                Console.WriteLine("Não encontrado!");
            }
            else
            {
                Console.WriteLine(m.ToString());
                if (m.FilaLotes.Count != 0)
                {
                    Console.WriteLine(m.FilaLotes.First().ToString());
                }
            }
        }
        private static void comprar(Medicamentos medicamentos)
        {
            Medicamento m = new Medicamento();

            Console.Write("Digite o id do medicamento: ");
            m.Id = int.Parse(Console.ReadLine());
            m = medicamentos.pesquisar(m);
            if (m == null)
            {
                Console.WriteLine("Não encontrado!");
            }
            else
            {
                Lote l = new Lote();
                Console.Write("Digite o id: ");
                l.Id = int.Parse(Console.ReadLine());
                Console.Write("Digite o qtde: ");
                l.Qtde = int.Parse(Console.ReadLine());
                Console.Write("Digite a data de vencimento: ");
                l.Venc = DateTime.Parse(Console.ReadLine());
                m.comprar(l);
            }
        }
        private static void vender(Medicamentos medicamentos)
        {
            Medicamento m = new Medicamento();

            Console.Write("Digite o id do medicamento: ");
            m.Id = int.Parse(Console.ReadLine());
            m = medicamentos.pesquisar(m);
            if (m == null)
            {
                Console.WriteLine("Não encontrado!");
            }
            else
            {
                Lote l = new Lote();
                Console.Write("Digite o id do lote: ");
                l.Id = int.Parse(Console.ReadLine());
                m.vender(l.Qtde);
            }
        }

        private static void mostar(Medicamentos medicamentos)
        {
            int posicao = 1;
            Console.WriteLine("Qtde de elementos: {0}", medicamentos.listaMedicamentos.Count);
            foreach (Medicamento m in medicamentos.listaMedicamentos)
            {
                Console.WriteLine("Medicamento {0}: {1}", posicao++, m.ToString());
            }
            Console.WriteLine("----------------");
        }
    }
}
