using System;

class Program
{
    static void Main(string[] args)
    {
        Medicamentos medicamentos = new Medicamentos();
        int opcao;

        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("0. Finalizar processo");
            Console.WriteLine("1. Cadastrar medicamento");
            Console.WriteLine("2. Consultar medicamento (sintético)");
            Console.WriteLine("3. Consultar medicamento (analítico)");
            Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
            Console.WriteLine("5. Vender medicamento (abater do lote mais antigo)");
            Console.WriteLine("6. Listar medicamentos (informando dados sintéticos)");
            Console.Write("Opção: ");
            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine() ?? "";
                    Console.Write("Laboratório: ");
                    string laboratorio = Console.ReadLine() ?? "";
                    medicamentos.Adicionar(new Medicamento(id, nome, laboratorio));
                    break;

                case 2:
                    Console.Write("ID do medicamento: ");
                    int idSintetico = int.Parse(Console.ReadLine() ?? "0");
                    Medicamento medSintetico = medicamentos.Pesquisar(idSintetico);
                    Console.WriteLine(medSintetico.ToString());
                    break;

                case 3:
                    Console.Write("ID do medicamento: ");
                    int idAnalitico = int.Parse(Console.ReadLine() ?? "0");
                    Medicamento medAnalitico = medicamentos.Pesquisar(idAnalitico);
                    Console.WriteLine(medAnalitico.ConsultarAnalitico());
                    break;

                case 4:
                    Console.Write("ID do medicamento: ");
                    int idCompra = int.Parse(Console.ReadLine() ?? "0");
                    Medicamento medCompra = medicamentos.Pesquisar(idCompra);
                    if (medCompra.Id != 0)
                    {
                        Console.Write("ID do lote: ");
                        int idLote = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Quantidade: ");
                        int qtde = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Data de vencimento (dd/mm/yyyy): ");
                        DateTime venc = DateTime.Parse(Console.ReadLine() ?? "01/01/2000");
                        medCompra.Comprar(new Lote(idLote, qtde, venc));
                    }
                    else
                    {
                        Console.WriteLine("Medicamento não encontrado.");
                    }
                    break;

                case 5:
                    Console.Write("ID do medicamento: ");
                    int idVenda = int.Parse(Console.ReadLine() ?? "0");
                    Medicamento medVenda = medicamentos.Pesquisar(idVenda);
                    if (medVenda.Id != 0)
                    {
                        Console.Write("Quantidade a vender: ");
                        int qtdeVenda = int.Parse(Console.ReadLine() ?? "0");
                        bool sucesso = medVenda.Vender(qtdeVenda);
                        Console.WriteLine(sucesso ? "Venda realizada com sucesso." : "Quantidade insuficiente.");
                    }
                    else
                    {
                        Console.WriteLine("Medicamento não encontrado.");
                    }
                    break;

                case 6:
                    foreach (var med in medicamentos.Listar())
                    {
                        Console.WriteLine(med.ToString());
                    }
                    break;

                case 0:
                    Console.WriteLine("Processo finalizado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 0);
    }
}
