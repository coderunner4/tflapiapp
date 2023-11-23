using Newtonsoft.Json;

namespace RoadStatus
{
    /// <summary>
    /// This contains the utility functions such as convertions
    /// </summary>
    static class Utils
    {
        /// <summary>
        /// Converts a JSON serialize string to List of <GenericType> Objects 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedJSONString"></param>
        /// <returns></returns>
        public static IEnumerable<T> DeserializeList<T>(this string serializedJSONString)
        {
            var obj = JsonConvert.DeserializeObject<IEnumerable<T>>(serializedJSONString);
            return obj;
        }

        /// <summary>
        /// Converts a JSON serialize string to <GenericType> Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedJSONString"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(this string serializedJSONString)
        {
            var obj = JsonConvert.DeserializeObject<T>(serializedJSONString);
            return obj;
        }
    }
}