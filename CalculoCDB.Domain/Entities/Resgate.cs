namespace CalculoCDB.Domain.Entities
{
    public class Resgate
    {
        #region properties
        public double ValorBruto { get; internal set; }
        public double ValorLiquido { get; internal set; }

        public const double TB = 1.08;
        public const double CDI = 0.009;
        public const double AteSEIS = 0.225;
        public const double AteDOZE = 0.2;
        public const double AteVINTEeQUATRO = 0.175;
        public const double AcimaVINTEeQUATRO = 0.15;
        #endregion

        #region Methods
        public Resgate()
        {
        }

        public Resgate(double valorBruto, double valorLiquido)
        {
            this.ValorBruto = valorBruto;
            this.ValorLiquido = valorLiquido;
        }

        public Resgate CalcularCDB(Rendimento rendimento)
        {
            var resultado = new Resgate();

            var vF = rendimento.Valor;  // VF = VI

            //A partir de agora a estrutura entra na repetição e depende da quantidade de meses de aplicação
            int i;
            for (i = 1; i <= rendimento.Prazo; i++)
            {
                vF *= (1 + (CDI * TB));
            }

            //Calculo do rendimento bruto que será utilizado no cálculo do imposto
            resultado.ValorBruto = vF - rendimento.Valor;

            if (rendimento.Prazo <= 6) //até 6 meses
            {
                resultado.ValorLiquido = resultado.ValorBruto * (1 - AteSEIS);
            }
            else if (rendimento.Prazo <= 12) //até 12 meses
            {
                resultado.ValorLiquido = resultado.ValorBruto * (1 - AteDOZE);
            }
            else if (rendimento.Prazo <= 24) // até 24 meses
            {
                resultado.ValorLiquido = resultado.ValorBruto * (1 - AteVINTEeQUATRO);
            }
            else //acima de 24 meses
            {
                resultado.ValorLiquido = resultado.ValorBruto * (1 - AcimaVINTEeQUATRO);
            }

            //Fiz este calculo para pegar o resultado do rendimento e somar com valor do investimento inicial

            resultado.ValorBruto += rendimento.Valor;
            resultado.ValorLiquido += rendimento.Valor;

            return resultado;
        }
        
        #endregion
    }
}