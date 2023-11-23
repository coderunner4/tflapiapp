using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RoadStatus
{
    class Program
    {
        static int Main(string[] args)
        {
            var roadid = args.Length > 0 ? args[0]: null;
            string roadStatusStr = "";
            if(roadid != null){
                try{
                    var _tfl = new TFLService();
                    var res = _tfl.GetRoadAsync(roadid).GetAwaiter().GetResult();
                    roadStatusStr = $"The status of the {res[0].displayName} is as follows\n\t Road Status is {res[0].statusSeverity}\n\t Road Status Description is {res[0].statusSeverityDescription}";
                    Console.WriteLine(roadStatusStr);
                    return 0;
                }
                catch(Exception e){
                    roadStatusStr = e.Message == "EntityNotFoundException" ?
                        $"{roadid} is not a valid road" : e.Message;
                }

            }else{
                roadStatusStr = "No input received";
            }

            Console.WriteLine($"Error: {roadStatusStr}");
            return 1;
       }
    }
}