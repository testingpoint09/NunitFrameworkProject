namespace NunitFrameworkProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method is calling..");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1  is calling..");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test2  is calling..");
        }
        [TearDown]
        public void closeBrowser()
        {
            TestContext.Progress.WriteLine("Close browser method is calling..");
        }
    }
}