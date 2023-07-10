using CalculoCDB.Services.Controllers;
using CalculoCDB.Services.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculoCDB.ServicesTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DevoCriarRendimentoModelComValorMonetarioePrazoEmMeses()
        {
            double valorMonetario = 20D;
            int prazoEmMeses = 2;

            RendimentoModel model = new RendimentoModel()
            {
                ValorMonetario = 20D,
                PrazoEmMeses = 2
            };

            Assert.AreEqual(valorMonetario, model.ValorMonetario);
            Assert.AreEqual(prazoEmMeses, model.PrazoEmMeses);



        }

        [TestMethod]
        public void DevoCriarResgateModelComValorLiquidoCalculadoeValorBrutoCalculado()
        {
            double valorBrutoCalculado = 20D;
            double valorLiquidoCalculado = 10D;

            ResgateModel model = new ResgateModel()
            {
                ValorBrutoCalculado = 20D,
                ValorLiquidoCalculado = 10D
            };

            Assert.AreEqual(valorBrutoCalculado, model.ValorBrutoCalculado);
            Assert.AreEqual(valorLiquidoCalculado, model.ValorLiquidoCalculado);
        }

    }
}
