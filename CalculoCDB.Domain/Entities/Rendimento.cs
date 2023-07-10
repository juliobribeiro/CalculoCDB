using System;

namespace CalculoCDB.Domain.Entities
{
    public class Rendimento
    {
        public double Valor { get; internal set; }
        public int Prazo { get; internal set; }

        public Rendimento(double valor, int prazo)
        {
            if (valor <= 0D)
                throw new ApplicationException("O campo Valor deve ser positivo.");

            if(prazo <= 1)
                throw new ApplicationException("O campo Prazo deve ser maior que 1 para resgate.");

            this.Valor = valor;
            this.Prazo = prazo;
        }

    }
}