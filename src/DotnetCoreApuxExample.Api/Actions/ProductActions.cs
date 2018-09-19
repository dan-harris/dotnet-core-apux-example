using Apux;
using DotnetCoreApuxExample.Api.Models;

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

    public class GetAllAction : ApuxActionBase
    {
        public GetAllAction() : base(ProductActions.GET_ALL) { }
    }

    public class GetByIdAction : ApuxAction<int>
    {
        public GetByIdAction(ApuxActionBase baseAction) : base(ProductActions.GET_BY_ID, baseAction) { }
        public GetByIdAction(int value) : base(ProductActions.GET_BY_ID, value) { }
    }

    public class UpdateAction : ApuxAction<Product>
    {
        public UpdateAction(ApuxActionBase basePayload) : base(ProductActions.UPDATE, basePayload) { }
        public UpdateAction(Product product) : base(ProductActions.UPDATE, product) { }
    }

}