using ProjetoTransporte;
using System;

namespace ProjetoTransporte
{
    public class Viagem
    {
        // Atributos privados
        private Garagem origem;
        private Garagem destino;
        private int passageiros;
        private Veiculo veiculo;

        // Construtor
        public Viagem(Garagem origem, Garagem destino, int passageiros, Veiculo veiculo)
        {
            this.origem = origem;
            this.destino = destino;
            this.passageiros = passageiros;
            this.veiculo = veiculo;
        }

        // Métodos públicos
        public Garagem GetOrigem()
        {
            return origem;
        }

        public Garagem GetDestino()
        {
            return destino;
        }

        public int GetPassageiros()
        {
            return passageiros;
        }

        public Veiculo GetVeiculo()
        {
            return veiculo;
        }
    }
}