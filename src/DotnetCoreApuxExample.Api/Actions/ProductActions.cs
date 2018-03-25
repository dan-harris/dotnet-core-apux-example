using System.Collections.Generic;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Actions
{

    /// <summary>
    /// List of Actions for this Apux Action namespace
    /// </summary>
    public class ProductActions
    {
        public const string GET_ALL = "PRODUCT_GET_ALL";
        public const string GET_BY_ID = "PRODUCT_GET_BY_ID";
        public const string UPDATE = "PRODUCT_UPDATE";

    }

    public class GetAllAction : ApuxAction<object>
    {
        public GetAllAction(JToken payload) : base(ProductActions.GET_ALL, payload) { }
    }

    public class GetByIdAction : ApuxAction<int>
    {
        public GetByIdAction(JToken payload) : base(ProductActions.GET_BY_ID, payload) { }
    }

    public class UpdateAction : ApuxAction<Product>
    {
        public UpdateAction(JToken payload) : base(ProductActions.UPDATE, payload) { }
    }

}