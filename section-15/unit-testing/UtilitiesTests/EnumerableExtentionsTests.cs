using NUnit.Framework;

namespace UtilitiesTests
{
    [TestFixture]
    public class EnumerableExtentionsTests
    {
        [Test]
        public void SumOfEvenNumbers_ShallReturnZero_IfEmptyCollection()
        {
            var input = Enumerable.Empty<int>();

            var result = input.SumOfEvenNumbers();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void SumOfEvenNumbers_ShallBe30_ForInput_1_To_10()
        {
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = input.SumOfEvenNumbers();

            Assert.AreEqual(30, result);
        }
    }
}
