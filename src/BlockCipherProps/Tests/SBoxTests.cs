using BlockCipherProps.Props;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlockCipherProps.Tests
{
    [TestClass]
    public class SBoxTests
    {
        private SBox? _sBox;

        [TestInitialize]
        public void Initialize()
        {
            byte[][] sBox = new byte[16][];
            byte[][] reversedSBox = new byte[16][];

            _sBox = new SBox(sBox, reversedSBox);
        }

        [TestMethod]
        public void TestSBox()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                byte sI = _sBox.Lookup((byte)i);
                byte rsI = _sBox.ReverseLookup(sI);

                Assert.AreEqual(i, rsI, $"S-box: got = {rsI}, want {i}");
            }
        }
    }
}