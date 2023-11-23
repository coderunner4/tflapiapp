namespace RoadStatus
{
    /// <summary>
    /// This contains all the global variables of application
    /// </summary>
    public static class Consts
    {
        /// <summary>
        /// This is api_key for TFL Api, change it with your own secret from TFL Api Portal
        /// </summary>
        public readonly static string TFL_API_KEY = "your_api_key";
        /// <summary>
        /// This is base address of TFL Api host
        /// </summary>
        public readonly static string TFL_API_HOST = "https://api.tfl.gov.uk";
        /// <summary>
        /// HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks. https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-7.0
        /// </summary>
        public readonly static HttpClient HttpClient = new() { BaseAddress = new Uri(TFL_API_HOST)};
    }
}