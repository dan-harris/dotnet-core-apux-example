using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public interface ICartActionHandler
    {
        ApuxActionResult AddProductAction(JToken data);
        ApuxActionResult RemoveProductAction(JToken data);
        ApuxActionResult ListProductsAction();
    }
}