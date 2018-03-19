using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{
    public interface IProductActionHandler
    {
        ApuxActionResult GetAll();
        ApuxActionResult GetById(JToken data);
    }
}