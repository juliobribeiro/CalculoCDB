using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoCDB.Application
{
    public interface ICalculoCDBApplicationService
    {
        ResgateDTO CalcularResgate(RendimentoDTO resgateDTO);
    }
}
