namespace ProjetoDeliverIT.Enumerators
{
    public enum StatusRetornoAPI
    {
        Sucesso = 200,

        ErroRegraNegocio = 400,
        ErroModelState = 422,
        NaoEncontrado = 404,
        ErroInterno = 500
    }

}
