
namespace MyCsLibrary0Test;

[TestClass]
public class UnitTest1
{
    public TestContext TestContext { get; set; } 

    [TestMethod]
    public void TestMethod1()
    {
        TestContext.WriteLine("in the future there will be tests here");
    }
}