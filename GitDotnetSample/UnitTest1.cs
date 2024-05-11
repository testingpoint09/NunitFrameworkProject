namespace GitDotnetSample
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Out.WriteLine("hi..");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}