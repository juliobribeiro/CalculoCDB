using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoCDB.Application.Teste
{
    [TestClass]
    public class Calculocdb
    {
        [TestMethod]
        public void DevoCriarRendimentoResgateDTO()
        {
            double valorMonetario = 20D;
            int prazoEmMeses = 2;

            RendimentoDTO dto = new RendimentoDTO()
            {
                ValorMonetario = 20D,
                PrazoEmMeses = 2
            };

            Assert.AreEqual(valorMonetario, dto.ValorMonetario);
            Assert.AreEqual(prazoEmMeses, dto.PrazoEmMeses);
        }

        [TestMethod]
        public void DevoCriarResgateDTO()
        {
            double valorBrutoCalculado = 20D;
            double valorLiquidoCalculado = 10D;

            ResgateDTO dto = new ResgateDTO()
            {
                ValorBrutoCalculado = 20D,
                ValorLiquidoCalculado = 10D
            };

            Assert.AreEqual(valorBrutoCalculado, dto.ValorBrutoCalculado);
            Assert.AreEqual(valorLiquidoCalculado, dto.ValorLiquidoCalculado);
        }

        [TestMethod]
        public void DevoCalcularOResgateERetonarOValorBrutoCalculadoEValorLiquidoCalculado()
        {
            var service = new CalculoCDBApplicationService();

            var valorBruto = 9.8626381615899845;
            var valorLiquido = 7.6435445752322382;

            var rendimentoDTO = new RendimentoDTO()
            {
                PrazoEmMeses = 4,
                ValorMonetario = 250D
            };

            var resgate = service.CalcularResgate(rendimentoDTO);

            Assert.AreEqual(valorLiquido, resgate.ValorLiquidoCalculado);
            Assert.AreEqual(valorBruto, resgate.ValorBrutoCalculado);
        }
    }
}
