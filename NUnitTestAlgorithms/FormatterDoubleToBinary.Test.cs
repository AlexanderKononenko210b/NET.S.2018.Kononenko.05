using System;
using NUnit.Framework;
using Algorithms;
using System.Linq;

namespace NUnitTestAlgorithms
{
    /// <summary>
    /// Test class for FormatterDoubleToBinary method
    /// </summary>
    [TestFixture]
    public class FormatterDoubleToBinary
    {
        /// <summary>
        /// Test method FormatterDoubleToBinary with valid data
        /// </summary>
        /// <param name="rezalt">expected result</param>
        /// <param name="inputData">input data</param>
        [TestCase(-255.255, "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, "0000000000000000000000000000000000000000000000000000000000000000")]
        public void NUnitTestAlgorithmOfEuclid_With_Valid_Data(double inputNumber, string result)
            => Assert.AreEqual(inputNumber.FormatterDoubleToBinary(), result);
            
    }
}