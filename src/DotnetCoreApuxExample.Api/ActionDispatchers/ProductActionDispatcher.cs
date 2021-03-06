using Apux;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Actions;

namespace DotnetCoreApuxExample.Api.ActionDispatchers
{

    /// <summary>
    /// Implements Actions for this Apux Action namespace, providing appropriate handler for an action
    /// </summary>
    public class ProductActionDispatcher : IApuxActionDispatcher
    {
        private readonly IAppErrorActionHandler _appErrorActionHandler;
        private readonly IProductActionHandler _productActionHandler;

        public ProductActionDispatcher(
            IAppErrorActionHandler appErrorActionHandler,
            IProductActionHandler productActionHandler
        )
        {
            _appErrorActionHandler = appErrorActionHandler;
            _productActionHandler = productActionHandler;
        }

        public ApuxActionResultBase Dispatch(ApuxActionBase actionRequest)
        {
            switch (actionRequest.Type)
            {
                case ProductActions.GET_ALL:
                    return _productActionHandler.GetAll(new GetAllAction());
                case ProductActions.GET_BY_ID:
                    return _productActionHandler.GetById(new GetByIdAction(actionRequest));
                case ProductActions.UPDATE:
                    return _productActionHandler.Update(new UpdateAction(actionRequest));
                default:
                    return _appErrorActionHandler.UnknownActionHandler(new UnknownActionAction());
            }
        }
    }
}