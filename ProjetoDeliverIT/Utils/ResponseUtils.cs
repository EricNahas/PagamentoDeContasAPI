using Microsoft.AspNetCore.Mvc;
using ProjetoDeliverIT.Enumerators;
using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.Utils
{
    public class ResponseUtils
    {
        public static RetornoAPI RetornoSucessoErro(StatusRetornoAPI status, string mensagem, object? dados = null)
        {
            return new RetornoAPI
            {
                MensagemRetorno = mensagem,
                StatusRetorno = (short)status,
                DadosRetorno = dados
            };
        }

        public static IActionResult RetornarRequisicaoResposta(ControllerBase controller, RetornoAPI result)
        {
            switch (result.StatusRetorno)
            {
                case (short)StatusRetornoAPI.Sucesso:
                    return controller.Ok(result);

                case (short)StatusRetornoAPI.ErroRegraNegocio:
                    return controller.BadRequest(result);

                case (short)StatusRetornoAPI.NaoEncontrado:
                    return controller.NotFound(result);

                case (short)StatusRetornoAPI.ErroInterno:
                default:
                    return controller.StatusCode(500, result);
            }
        }

        //Caso haja necessidade de um retorno da Classe
        public static T? ConverterParaClasseDesejada<T>(RetornoAPI retornoAPI)
        {
            if (retornoAPI.DadosRetorno is T valor)
                return valor;

            return default;
        }
    }
}
