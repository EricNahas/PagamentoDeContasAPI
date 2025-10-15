namespace ProjetoDeliverIT.Enumerators
{
    public enum StatusRetornoAPI
    {
        ErroRegraNegocio = 1,
        ErroModelState = 2,
        Sucesso = 200,
        //Não implementado retorno 300 por não haver necessidade no momento
        NaoEncontrado = 400,
        ErroInterno = 500,
    }
}
