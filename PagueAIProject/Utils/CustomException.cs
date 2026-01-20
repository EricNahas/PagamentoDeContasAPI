using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.Utils
{
    public class CustomException : Exception
    {
        public RetornoAPI RetornoAPI;
        public CustomException(RetornoAPI retorno) { RetornoAPI = retorno; }
    }
}
