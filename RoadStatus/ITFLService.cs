namespace RoadStatus
{
    public interface ITFLService
    {
        public Task<List<Road>> GetRoadAsync(string roadid);
    }
}