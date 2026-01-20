using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PocTresCamadas.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected bool OperacaoValida()
    {
        return !ModelState.Values.SelectMany(m => m.Errors).Any();
    }

    protected ActionResult CustomResponse(object? result = null)
    {
        if (OperacaoValida())
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(new
            {
                errors = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)
            });
        }
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            foreach (var error in modelState.Values.SelectMany(m => m.Errors))
            {
                //AdicionarErroProcessamento(error.ErrorMessage);
            }
        }

        return CustomResponse();
    }

    protected void NotificarErro(string mensagem)
    {
        ModelState.AddModelError(string.Empty, mensagem);
    }
}
