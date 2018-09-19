using Apux;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.Models;
using System.Collections.Generic;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{
    public interface IProductActionHandler
    {
        ApuxActionResult<List<Product>> GetAll(GetAllAction action);
        ApuxActionResultBase GetById(GetByIdAction action);
        ApuxActionResult<Product> Update(UpdateAction action);
    }
}