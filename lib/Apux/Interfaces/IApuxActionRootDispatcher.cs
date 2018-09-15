using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Apux
{
    public interface IApuxActionRootDispatcher
    {

        /// <summary>
        /// Root dispatcher
        /// Handles the dispatching of actions, using action namespace to direct action to appropriate action dispatcher
        /// for namespace.
        /// Also allows recursive calls, meaning actions can be 'chained' internally, with an action returning an action.
        /// </summary>
        /// <param name="actionRequest">The dispatch request action</param>
        /// <returns></returns>
        ApuxActionResultBase RootDispatch(ApuxActionBase actionRequest);

        /// <summary>
        /// Dispatches an action from root dispatch to child namespace dispatchers
        /// </summary>
        /// <param name="actionNamespace">The namespace of the action</param>
        /// <param name="action">The dispatch request action, with payload parsed to JSON</param>
        /// <returns></returns>
        ApuxActionResultBase Dispatch(string actionNamespace, ApuxActionBase action);

    }
}