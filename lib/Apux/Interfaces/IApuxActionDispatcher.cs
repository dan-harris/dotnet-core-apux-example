namespace Apux
{
    public interface IApuxActionDispatcher
    {
        /// <summary>
        /// Dispatch an action to the appropriate handler, using its Action Type
        /// </summary>
        /// <param name="actionRequest">The dispatch request action</param>
        /// <returns></returns>
        ApuxActionResultBase Dispatch(ApuxActionBase actionRequest);
    }
}