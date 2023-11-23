using System.Diagnostics;
using System.Net.Http.Headers;

namespace RoadStatus
{
    public class TFLService
    {
        public async Task<List<Road>> GetRoadAsync(string roadid)
        {   
            List<Road> roads = new List<Road>();

            var roadendpoint_url = $"{Consts.TFL_API_HOST}/road/{roadid}";
            var qry = $"?app_id=myapp&api_key={Consts.TFL_API_KEY}";

            using var client = new HttpClient();
            client.BaseAddress = new Uri(roadendpoint_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Debug.WriteLine($"Get Road by Id {roadid}");
            HttpResponseMessage response = await client.GetAsync(qry);
            // response.EnsureSuccessStatusCode(); //enabling this throw exception for all failours
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var obj = Utils.DeserializeList<Road>(jsonString).ToList();
                if(obj != null){
                    roads.AddRange(obj);
                }
            }
            else{
                var jsonString = await response.Content.ReadAsStringAsync();
                var obj = Utils.DeserializeObject<TFLServiceException>(jsonString);
                if(obj != null){
                    var ex = new Exception(obj.exceptionType);
                    ex.Data.Add("httpStatusCode", obj.httpStatusCode.ToString());
                    ex.Data.Add("message", obj.message);
                    throw ex;
                }
            }
           
            return roads;
        }
    }
}