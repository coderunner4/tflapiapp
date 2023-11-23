using RoadStatus;

namespace RoadStatusTest;

[TestClass]
public class RoadUnitTests
{
    [TestMethod]
    public void GetRoadAsync_ValidateEndpoint()
    {
        try{
            var _tfl = new TFLService();
            var res = _tfl.GetRoadAsync("A40").GetAwaiter().GetResult();
            Assert.IsNotNull(res);
        }
        catch {
            Assert.Fail("Invalid Request");
        }
    }

    [TestMethod]
    public void GetRoadAsync_InvalidRoadId()
    {
        var roadid = "A333";
        try{
            var _tfl = new TFLService();
            var res = _tfl.GetRoadAsync(roadid).GetAwaiter().GetResult();
            Assert.Fail("Should have raised exception");
        }
        catch(Exception ex){
            Assert.AreEqual("EntityNotFoundException", ex.Message, true);
        }
    }

    [TestMethod]
    public void GetRoadAsync_CheckDisplayName()
    {
        var roadid = "A40";
        try{
            var _tfl = new TFLService();
            var res = _tfl.GetRoadAsync(roadid).GetAwaiter().GetResult();
            Assert.AreEqual(roadid, res[0].displayName, true);
        }
        catch{
            Assert.Fail("Invalid Request");
        }
    }

    [TestMethod]
    public void GetRoadAsync_StatusSeverityNotNull()
    {
        var roadid = "A40";
        try{
            var _tfl = new TFLService();
            var res = _tfl.GetRoadAsync(roadid).GetAwaiter().GetResult();
            
            Assert.IsNotNull(res[0].statusSeverity);
        }
        catch{
            Assert.Fail("Invalid Request");
        }
    }
    
    [TestMethod]
    public void GetRoadAsync_StatusSeverityDescriptionNotNull()
    {
        var roadid = "A40";
        try{
            var _tfl = new TFLService();
            var res = _tfl.GetRoadAsync(roadid).GetAwaiter().GetResult();
            
            Assert.IsNotNull(res[0].statusSeverityDescription);
        }
        catch{
            Assert.Fail("Invalid Request");
        }
    }
}