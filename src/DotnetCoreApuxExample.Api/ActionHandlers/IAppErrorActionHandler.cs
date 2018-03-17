using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public interface IAppErrorActionHandler
    {

        ApuxActionResult UnknownAction();

    }
}