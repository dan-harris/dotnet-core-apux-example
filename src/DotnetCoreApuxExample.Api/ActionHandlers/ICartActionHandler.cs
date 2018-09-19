using Apux;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.Models;
using System.Collections.Generic;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{
    public interface ICartActionHandler
    {
        ApuxActionResult<bool> AddProductHandler(AddProductAction action);
        ApuxActionResult<bool> RemoveProductHandler(RemoveProductAction action);
        ApuxActionResult<List<Product>> ListProductsHandler(ListProductsAction action);
        ApuxActionResult<int> GetProductTotalPriceHandler(GetTotalPriceAction action);
    }
}