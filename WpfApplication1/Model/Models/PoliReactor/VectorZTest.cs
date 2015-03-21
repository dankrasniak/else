using NUnit.Framework;

namespace WpfApplication1.Model.Models.PoliReactor
{
    [TestFixture]
    public class VectorZTest
    {
#region PropperFunctionality

        [Test]
        public void OperatorSum()
        {
            var tested = new VectorZ(1.0, 2.0, 3.0, 4.0);
            var addition = new VectorZ(1.0, 2.0, 3.0, 4.0);

            tested = tested + addition;
            var expectedResult = new VectorZ(2.0, 4.0, 6.0, 8.0);

            Assert.AreEqual(tested.Get(0), expectedResult.Get(0));
            Assert.AreEqual(tested.Get(1), expectedResult.Get(1));
            Assert.AreEqual(tested.Get(2), expectedResult.Get(2));
            Assert.AreEqual(tested.Get(3), expectedResult.Get(3));
        }

        [Test]
        public void Get()
        {
            var tested = new VectorZ(1.0, 2.0, 3.0, 4.0);

            Assert.AreEqual(tested.Get(0), 1.0);
            Assert.AreEqual(tested.Get(1), 2.0);
            Assert.AreEqual(tested.Get(2), 3.0);
            Assert.AreEqual(tested.Get(3), 4.0);
        }

        [Test]
        public void OperatorMultiplication()
        {
            var tested = new VectorZ(1.0, 2.0, 3.0, 4.0);

            tested = 2.0 * tested;

            Assert.AreEqual(tested.Get(0), 2.0);
            Assert.AreEqual(tested.Get(1), 4.0);
            Assert.AreEqual(tested.Get(2), 6.0);
            Assert.AreEqual(tested.Get(3), 8.0);
        }

        [Test]
        public void CopyingConstructor()
        {
            var copied = new VectorZ(1.0, 2.0, 3.0, 4.0);
            var tested = new VectorZ(copied);

            Assert.AreEqual(tested.Get(0), 1.0);
            Assert.AreEqual(tested.Get(1), 2.0);
            Assert.AreEqual(tested.Get(2), 3.0);
            Assert.AreEqual(tested.Get(3), 4.0);
        }
#endregion PropperFunctionality
    }
}