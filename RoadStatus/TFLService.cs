using System.Diagnostics;
using System.Net.Http.Headers;

namespace RoadStatus
{
    public class TFLService : ITFLService
    {
        public async Task<List<Road>> GetRoadAsync(string roadid)
        {   
            List<Road> roads = new List<Road>();

            // Construct the url for road endpoint, fill api_host and api_key from global vars 
            var qry = $"/road/{roadid}?app_id=myapp&api_key={Consts.TFL_API_KEY}";

            // Construct the httpclient with json content type
            var client = Consts.HttpClient;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Debug.WriteLine($"Get Road by Id {roadid}");
            HttpResponseMessage response = await client.GetAsync(qry);
            // response.EnsureSuccessStatusCode(); //Enabling this throw exception for any failour which is not required for now
            if (response.IsSuccessStatusCode)
            {
                // Read the response message string and convert to list of roads 
                var jsonString = await response.Content.ReadAsStringAsync();
                var obj = Utils.DeserializeList<Road>(jsonString).ToList();
                if(obj != null){
                    roads.AddRange(obj);
                }
            }
            else{
                // Read the failure response message and covert to generic exception to be thrown 
                // for other services to handle errors accordingly
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