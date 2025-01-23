using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    public class Veiculo
    {
        // Atributos privados
        private int id;
        private int capacidade;
        private int passageiros;

        // Construtor
        public Veiculo(int id, int capacidade)
        {
            this.id = id;
            this.capacidade = capacidade;
            this.passageiros = 0;
        }

        // Métodos públicos
        public int GetId()
        {
            return id;
        }

        public int GetCapacidade()
        {
            return capacidade;
        }

        public int GetPassageiros()
        {
            return passageiros;
        }

        public void AdicionarPassageiro()
        {
            if (passageiros < capacidade)
            {
                passageiros++;
            }
            else
            {
                throw new InvalidOperationException("Capacidade máxima atingida");
            }
        }

        public void LimparPassageiros()
        {
            passageiros = 0;
        }
    }
}