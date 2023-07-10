using CalculoCDB.Application;
using CalculoCDB.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResgateController : ControllerBase
    {
        
        private readonly ICalculoCDBApplicationService _service;

        public ResgateController(ICalculoCDBApplicationService service)
        {
            if (service == null)
                BadRequest();

            _service = service;
        }

        [HttpPost]
        public IActionResult Calcular([FromBody]RendimentoModel rendimento)
        {
            try
            {
                RendimentoDTO dto = new RendimentoDTO()
                {
                    PrazoEmMeses = rendimento.PrazoEmMeses,
                    ValorMonetario = rendimento.ValorMonetario
                };

                var calculoRetorno = _service.CalcularResgate(dto);

                ResgateModel model = new ResgateModel()
                {
                    ValorBrutoCalculado = calculoRetorno.ValorBrutoCalculado,
                    ValorLiquidoCalculado = calculoRetorno.ValorLiquidoCalculado
                };

                return Ok(model);
            }
            catch (System.ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
