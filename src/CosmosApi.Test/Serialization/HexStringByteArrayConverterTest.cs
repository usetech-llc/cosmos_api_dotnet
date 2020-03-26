using System.Linq;
using CosmosApi.Serialization;
using Xunit;

namespace CosmosApi.Test.Serialization
{
    public class HexStringByteArrayConverterTest
    {
        [Fact]
        public void ByteArrayConvertsToStringCorrectly()
        {
            var allBytes = Enumerable.Range(0, 256).Select(n => (byte) n).ToArray();
            var str = string.Join("", allBytes.Select(b => b.ToString("X2")));
            
            Assert.Equal(str, HexStringByteArrayConverter.ToString(allBytes));
        }

        [Fact]
        public void StringConvertsToByteArrayCorrectly()
        {
            var allBytes = Enumerable.Range(0, 256).Select(n => (byte) n).ToArray();
            var str = string.Join("", allBytes.Select(b => b.ToString("X2")));

            Assert.Equal(allBytes, HexStringByteArrayConverter.ToByteArray(str));
        }
    }
}