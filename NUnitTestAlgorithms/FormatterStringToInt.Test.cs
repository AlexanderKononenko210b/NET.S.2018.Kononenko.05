using System;
using NUnit.Framework;
using Algorithms;

namespace NUnitTestAlgorithms
{
    /// <summary>
    /// Test class for testing method FormatterStringToInt
    /// </summary>
    [TestFixture]
    public class FormatterStringToInt
    {
        /// <summary>
        /// Test method FormatterStringToInt with valid data
        /// </summary>
        /// <param name="inputString">input string</param>
        /// <param name="base">base system number</param>
        /// <param name="result">expected result</param>
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("1101", 2, 13)]
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("11101101111011001100001010", 2,  62370570)]
        [TestCase("1AeF101",  16,  28242177)]
        [TestCase("1ACB67",  16,  1756007)]
        [TestCase("764241",  8,  256161)]
        [TestCase("10",  5,  5)]
        public void FormatterStringToInt_With_Valid_Data(string inputString, int @base, int result)
					=> Assert.AreEqual(AlgorithmsMethods.FormatterStringToInt(inputString, @base), result);

        /// <summary>
        /// Test method FormatterStringToInt expected ArgumentException
        /// </summary>
        /// <param name="inputString">input string</param>
        /// <param name="base">base system number</param>
        [TestCase("1AeF101",  2)]
        [TestCase("SA123",  2)]
        [TestCase("764241",  20)]
        [TestCase("", 20)]
        [TestCase(null, 20)]
        [TestCase(" ", 20)]
        public void FormatterStringToInt_Expected_ArgumentException(string inputString, int @base)
                    => Assert.Throws<ArgumentException>(() => AlgorithmsMethods.FormatterStringToInt(inputString, @base));

        /// <summary>
        /// Test method FormatterStringToInt expected OverflowException
        /// </summary>
        /// <param name="inputString">input string</param>
        /// <param name="base">base system number</param>
        [TestCase("11111111111111111111111111111111", 2)]
        public void FormatterStringToInt_Expected_OverflowException(string inputString, int @base)
                    => Assert.Throws<OverflowException>(() => AlgorithmsMethods.FormatterStringToInt(inputString, @base));
    }
}
