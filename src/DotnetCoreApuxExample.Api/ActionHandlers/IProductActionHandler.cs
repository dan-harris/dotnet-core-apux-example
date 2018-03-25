using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{
    public interface IProductActionHandler
    {
        ApuxActionResult<List<Product>> GetAll(GetAllAction action);
        IApuxActionResult GetById(GetByIdAction action);
        ApuxActionResult<Product> Update(UpdateAction action);
    }
}