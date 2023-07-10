using CalculoCDB.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculoCDB.Domain.Teste
{
    [TestClass]
    public class CalculoCdb
    {
        #region Dados
        [TestMethod]
        public void DevoCriarEntidadeRendimentoComValorEPrazoValidos()
        {
            var valor = 50D;
            var prazo = 4;

            Rendimento dados = new Rendimento(valor, prazo);

            Assert.AreEqual(valor, dados.Valor);
            Assert.AreEqual(prazo, dados.Prazo);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void QuandoCrioAEntidadeRendimentoComValorMenorQueZeroDevoRetornarUmaException()
        {
            var valor = -1D;
            var prazo = 4;

            _ = new Rendimento(valor, prazo);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void QuandoCrioAEntidadeRendimentoComValorIgualAZeroDevoRetornarUmaException()
        {
            var valor = 0D;
            var prazo = 4;

            _ = new Rendimento(valor, prazo);
        }
        #endregion

        #region Resultado
        [TestMethod]
        public void DevoCriarEntidadeResgateComValorLiquidoEValorBrutoValido()
        {
            double valorBruto = 50D;
            double valorLiquido = 15D;

            Resgate resgate = new Resgate(valorBruto, valorLiquido);

            Assert.AreEqual(valorBruto, resgate.ValorBruto);
            Assert.AreEqual(valorLiquido, resgate.ValorLiquido);
        }

        [TestMethod]
        public void DevoCriarOCalcularCDBeRetornarValorLiquidoEValorBrutoValido()
        {
            var valor = 250D;
            var prazo = 4;
            var valorBruto = 259.86263816159;
            var valorLiquido = 257.64354457523223;

            Rendimento rendimento = new Rendimento(valor, prazo);

            Resgate resgate = new Resgate();

            var resultado = resgate.CalcularCDB(rendimento);

            Assert.AreEqual(resultado.ValorBruto, valorBruto);
            Assert.AreEqual(resultado.ValorLiquido,valorLiquido);
        }
        #endregion

        
    }
}
