namespace RoadStatus
{
    /// <summary>
    /// ITFLService provides interface to TFL APi to fetch road information
    /// </summary>
    public interface ITFLService
    {
        /// <summary>
        /// Call the Road Endpoint with given roadid
        /// </summary>
        /// <param name="roadid">Road id</param>
        /// <returns>List of roads</returns>
        public Task<List<Road>> GetRoadAsync(string roadid);
    }
}