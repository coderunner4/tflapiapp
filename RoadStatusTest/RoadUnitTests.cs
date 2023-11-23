using RoadStatus;

namespace RoadStatusTest;

[TestClass]
public class RoadUnitTests
{
    [TestMethod]
    public void GetRoadAsync_ValidateEndpoint()
    {
        // If request is valid, the api should return a non-null object
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
        // If invalid road id is given, the api should throw a EntityNotFoundException exception
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
        // If valid road id is given, the api returns a list of matching road objects.
        // The first object's road id should match to given road id
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
        // If valid road id is given, the api returns a list of matching road objects. 
        // The first object's road status code is available
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
        // If valid road id is given, the api returns a list of matching road objects.
        // The first object's road status description is available
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