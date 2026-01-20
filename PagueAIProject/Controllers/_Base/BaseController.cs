using Microsoft.AspNetCore.Mvc;
using ProjetoDeliverIT.Enumerators;
using ProjetoDeliverIT.EnumeratorsExtensions;
using ProjetoDeliverIT.Models;
using ProjetoDeliverIT.Utils;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult PostWithRabbitMQ<T>(
        T model,
        Func<T, RetornoAPI> insertFunc,
        Action<T>? onSuccess = null)
    {
        if (!ModelState.IsValid)
        {
            var erros = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            var retornoErro = ResponseUtils.RetornoSucessoErro(
                StatusRetornoAPI.ErroModelState,
                MensagemRetornoAPI.ErroModelState,
                erros
            );

            return ResponseUtils.RetornarRequisicaoResposta(this, retornoErro);
        }

        var result = insertFunc(model);

        if (StatusRetornoApiExtensions.IsSucesso(result.StatusRetorno))
        {
            onSuccess?.Invoke(model);
        }

        return ResponseUtils.RetornarRequisicaoResposta(this, result);
    }
}
