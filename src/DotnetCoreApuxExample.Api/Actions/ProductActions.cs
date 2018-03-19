using System.Collections.Generic;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Models;

namespace DotnetCoreApuxExample.Api.Actions
{

    /// <summary>
    /// List of Actions for this Apux Action namespace
    /// </summary>
    public class ProductActionsList
    {
        public const string GET_ALL = "GET_ALL";
        public const string GET_BY_ID = "GET_BY_ID";
    }

    /// <summary>
    /// Implements Actions for this Apux Action namespace, providing appropriate handler for an action
    /// </summary>
    public class ProductActions : IApuxAction
    {

        private readonly IAppErrorActionHandler _appErrorActionHandler;
        private readonly IProductActionHandler _productActionHandler;

        public ProductActions(
            IAppErrorActionHandler appErrorActionHandler,
            IProductActionHandler productActionHandler
        )
        {
            _appErrorActionHandler = appErrorActionHandler;
            _productActionHandler = productActionHandler;
        }

        public ApuxActionResult executeAction(ApuxActionRequest actionRequest)
        {

            var result = _appErrorActionHandler.UnknownAction();

            switch (actionRequest.Action)
            {
                case ProductActionsList.GET_ALL:
                    {
                        result = _productActionHandler.GetAll();
                    }
                    break;

                case ProductActionsList.GET_BY_ID:
                    {
                        result = _productActionHandler.GetById(actionRequest.Data);
                    }
                    break;

                default:
                    {
                        result = _appErrorActionHandler.UnknownAction();
                    }
                    break;
            }

            return result;


        }

    }
}