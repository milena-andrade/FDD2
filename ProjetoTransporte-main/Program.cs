using System;
using System.Collections.Generic;

namespace ProjetoTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            ControleFrota controleFrota = new ControleFrota();

            while (true)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("0. Finalizar");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Cadastrar garagem");
                Console.WriteLine("3. Iniciar jornada");
                Console.WriteLine("4. Encerrar jornada");
                Console.WriteLine("5. Liberar viagem de uma determinada origem para um determinado destino");
                Console.WriteLine("6. Listar veículos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)");
                Console.WriteLine("7. Informar quantidade de viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("8. Listar viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("9. Informar quantidade de passageiros transportados de uma determinada origem para um determinado destino");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        return;
                    case 1:
                        CadastrarVeiculo(controleFrota);
                        break;
                    case 2:
                        CadastrarGaragem(controleFrota);
                        break;
                    case 3:
                        controleFrota.IniciarJornada();
                        break;
                    case 4:
                        controleFrota.EncerrarJornada();
                        break;
                    case 5:
                        LiberarViagem(controleFrota);
                        break;
                    case 6:
                        ListarVeiculos(controleFrota);
                        break;
                    case 7:
                        InformarQtdViagens(controleFrota);
                        break;
                    case 8:
                        ListarViagens(controleFrota);
                        break;
                    case 9:
                        InformarQtdPassageirosTransportados(controleFrota);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarVeiculo(ControleFrota controleFrota)
        {
            Console.Write("Digite o ID do veículo: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite a capacidade do veículo: ");
            int capacidade = int.Parse(Console.ReadLine());
            Veiculo veiculo = new Veiculo(id, capacidade);
            controleFrota.CadastrarVeiculo(veiculo);
        }

        static void CadastrarGaragem(ControleFrota controleFrota)
        {
            Console.Write("Digite o ID da garagem: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite o local da garagem: ");
            string local = Console.ReadLine();
            Garagem garagem = new Garagem(id, local);
            controleFrota.CadastrarGaragem(garagem);
        }

        static void LiberarViagem(ControleFrota controleFrota)
        {
            Console.Write("Digite o ID da garagem de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o ID da garagem de destino: ");
            int idDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o ID do veículo: ");
            int idVeiculo = int.Parse(Console.ReadLine());

            Garagem origem = controleFrota.garagens.Find(g => g.GetId() == idOrigem);
            Garagem destino = controleFrota.garagens.Find(g => g.GetId() == idDestino);
            Veiculo veiculo = controleFrota.veiculos.Find(v => v.GetId() == idVeiculo);

            if (origem != null && destino != null && veiculo != null)
            {
                controleFrota.LiberarViagem(origem, destino, veiculo);
            }
            else
            {
                Console.WriteLine("Origem, destino ou veículo inválidos!");
            }
        }

        static void ListarVeiculos(ControleFrota controleFrota)
        {
            Console.Write("Digite o ID da garagem: ");
            int idGaragem = int.Parse(Console.ReadLine());

            Garagem garagem = controleFrota.garagens.Find(g => g.GetId() == idGaragem);

            if (garagem != null)
            {
                List<Veiculo> veiculos = controleFrota.ListarVeiculos(garagem);
                Console.WriteLine($"Veículos na garagem {garagem.GetLocal()}:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"ID: {veiculo.GetId()}, Capacidade: {veiculo.GetCapacidade()}, Passageiros: {veiculo.GetPassageiros()}");
                }
            }
            else
            {
                Console.WriteLine("Garagem inválida!");
            }
        }

        static void InformarQtdViagens(ControleFrota controleFrota)
        {
            Console.Write("Digite o ID da garagem de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o ID da garagem de destino: ");
            int idDestino = int.Parse(Console.ReadLine());

            Garagem origem = controleFrota.garagens.Find(g => g.GetId() == idOrigem);
            Garagem destino = controleFrota.garagens.Find(g => g.GetId() == idDestino);

            if (origem != null && destino != null)
            {
                int qtdViagens = controleFrota.QtdViagens(origem, destino);
                Console.WriteLine($"Quantidade de viagens de {origem.GetLocal()} para {destino.GetLocal()}: {qtdViagens}");
            }
            else
            {
                Console.WriteLine("Origem ou destino inválidos!");
            }
        }

        static void ListarViagens(ControleFrota controleFrota)
        {
            Console.Write("Digite o ID da garagem de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o ID da garagem de destino: ");
            int idDestino = int.Parse(Console.ReadLine());

            Garagem origem = controleFrota.garagens.Find(g => g.GetId() == idOrigem);
            Garagem destino = controleFrota.garagens.Find(g => g.GetId() == idDestino);

            if (origem != null && destino != null)
            {
                List<Viagem> viagens = controleFrota.ListarViagens(origem, destino);
                Console.WriteLine($"Viagens de {origem.GetLocal()} para {destino.GetLocal()}:");
                foreach (var viagem in viagens)
                {
                    Console.WriteLine($"Veículo ID: {viagem.GetVeiculo().GetId()}, Passageiros: {viagem.GetPassageiros()}");
                }
            }
            else
            {
                Console.WriteLine("Origem ou destino inválidos!");
            }
        }

        static void InformarQtdPassageirosTransportados(ControleFrota controleFrota)
        {
            Console.Write("Digite o ID da garagem de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o ID da garagem de destino: ");
            int idDestino = int.Parse(Console.ReadLine());

            Garagem origem = controleFrota.garagens.Find(g => g.GetId() == idOrigem);
            Garagem destino = controleFrota.garagens.Find(g => g.GetId() == idDestino);

            if (origem != null && destino != null)
            {
                int qtdPassageiros = controleFrota.QtdPassageirosTransportados(origem, destino);
                Console.WriteLine($"Quantidade de passageiros transportados de {origem.GetLocal()} para {destino.GetLocal()}: {qtdPassageiros}");
            }
            else
            {
                Console.WriteLine("Origem ou destino inválidos!");
            }
        }
    }
}