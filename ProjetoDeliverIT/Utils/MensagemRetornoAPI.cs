namespace ProjetoDeliverIT.Utils
{
    public static class MensagemRetornoAPI
    {
        public const string Sucesso = "Operação realizada com sucesso.";
        public const string ErroInterno = "Erro interno do servidor.";
        public const string ErroValidacao = "Erro de validação.";
        public const string ErroModelState = "Erro de validação nos seguintes campos";

        public static class Conta
        {
            public const string InseridaSucesso = "Conta inserida com sucesso.";
        }

        public static class ContaRegraAtraso
        {
            public const string RegraSemAtrasoExistente = "Conta pagas em dia não devem possuir Regras de Atraso.";
            public static string RegraNaoEncontarda(int dias)
            { 
                return $"Regra de atraso não encontrada para: {dias} dia{(dias > 1 ? "s" : "")} de atraso."; 
            }
        }
    }
}
