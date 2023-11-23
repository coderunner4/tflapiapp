using Newtonsoft.Json;

namespace RoadStatus
{
    static class Utils
    {
        public static IEnumerable<T> DeserializeList<T>(this string serializedJSONString)
        {
            var obj = JsonConvert.DeserializeObject<IEnumerable<T>>(serializedJSONString);
            return obj;
        }

        public static T DeserializeObject<T>(this string serializedJSONString)
        {
            var obj = JsonConvert.DeserializeObject<T>(serializedJSONString);
            return obj;
        }
    }
}