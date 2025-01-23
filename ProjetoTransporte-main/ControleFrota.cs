using System;
using System.Collections.Generic;

namespace ProjetoTransporte
{
    public class ControleFrota
    {
        // Atributos privados
        public List<Garagem> garagens;
        public List<Veiculo> veiculos;
        public List<Viagem> viagens;

        // Construtor
        public ControleFrota()
        {
            garagens = new List<Garagem>();
            veiculos = new List<Veiculo>();
            viagens = new List<Viagem>();
        }

        // Métodos públicos
        public void CadastrarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }

        public void CadastrarGaragem(Garagem garagem)
        {
            garagens.Add(garagem);
        }

        public void IniciarJornada()
        {
            // Distribuir alternadamente os veículos entre as garagens
            int garagemIndex = 0;
            foreach (var veiculo in veiculos)
            {
                garagens[garagemIndex].AdicionarVeiculo(veiculo);
                garagemIndex = (garagemIndex + 1) % garagens.Count;
            }
        }

        public void EncerrarJornada()
        {
            // Gerar lista de veículos e limpar ocorrências de viagens
            foreach (var veiculo in veiculos)
            {
                veiculo.LimparPassageiros();
            }
        }

        public void LiberarViagem(Garagem origem, Garagem destino, Veiculo veiculo)
        {
            if (origem.ListarVeiculos().Contains(veiculo))
            {
                origem.RemoverVeiculo(veiculo);
                destino.AdicionarVeiculo(veiculo);
                Viagem viagem = new Viagem(origem, destino, veiculo.GetPassageiros(), veiculo);
                viagens.Add(viagem);
            }
            else
            {
                throw new InvalidOperationException("O veículo não está disponível na garagem de origem");
            }
        }

        public List<Veiculo> ListarVeiculos(Garagem garagem)
        {
            return garagem.ListarVeiculos();
        }

        public int QtdViagens(Garagem origem, Garagem destino)
        {
            int count = 0;
            foreach (var viagem in viagens)
            {
                if (viagem.GetOrigem() == origem && viagem.GetDestino() == destino)
                {
                    count++;
                }
            }
            return count;
        }

        public List<Viagem> ListarViagens(Garagem origem, Garagem destino)
        {
            List<Viagem> viagensEfetuadas = new List<Viagem>();
            foreach (var viagem in viagens)
            {
                if (viagem.GetOrigem() == origem && viagem.GetDestino() == destino)
                {
                    viagensEfetuadas.Add(viagem);
                }
            }
            return viagensEfetuadas;
        }

        public int QtdPassageirosTransportados(Garagem origem, Garagem destino)
        {
            int totalPassageiros = 0;
            foreach (var viagem in viagens)
            {
                if (viagem.GetOrigem() == origem && viagem.GetDestino() == destino)
                {
                    totalPassageiros += viagem.GetPassageiros();
                }
            }
            return totalPassageiros;
        }
    }
}