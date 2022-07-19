using MySerialize;
using Xunit;
namespace MySerialize.UnitTest
{
    public class TestSerialize
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            string res = StartTesting.StartTest();
            Assert.Equal("Success", res);
        }
    }
}
