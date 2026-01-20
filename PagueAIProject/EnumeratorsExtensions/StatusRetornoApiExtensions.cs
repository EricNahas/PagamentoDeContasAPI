using ProjetoDeliverIT.Enumerators;

namespace ProjetoDeliverIT.EnumeratorsExtensions
{
    public static class StatusRetornoApiExtensions
    {
        public static bool IsSucesso(this short status)
        {
            return status >= 200 && status < 300;
        }
    }

}
