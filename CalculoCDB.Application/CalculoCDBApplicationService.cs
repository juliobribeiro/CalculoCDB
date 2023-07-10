using CalculoCDB.Domain.Entities;

namespace CalculoCDB.Application
{
    public class CalculoCDBApplicationService : ICalculoCDBApplicationService
    {
        public ResgateDTO CalcularResgate(RendimentoDTO rendimentoDTO)
        {
            Rendimento entidadeRendimento = new Rendimento(rendimentoDTO.ValorMonetario, rendimentoDTO.PrazoEmMeses);

            Resgate entidadeResgate = new Resgate();
            var retornoEntidadeResgate = entidadeResgate.CalcularCDB(entidadeRendimento);

            ResgateDTO resgateDTO = new ResgateDTO() 
            { 
                ValorBrutoCalculado = retornoEntidadeResgate.ValorBruto,
                ValorLiquidoCalculado = retornoEntidadeResgate.ValorLiquido
            };

            return resgateDTO;
        }
    }

}
