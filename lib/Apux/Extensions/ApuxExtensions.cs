namespace Apux.Extensions
{

    public static class ApuxExtensions
    {

        public static ApuxActionResult<T> ToApuxActionResult<T>(this T obj)
        {
            return new ApuxActionResult<T>(obj);
        }

    }

}