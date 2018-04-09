using System;
using NUnit.Framework;
using Algorithms;

namespace NUnitTestAlgorithms
{
	[TestFixture]
	public class EuclidMethods
	{
        /// <summary>
        /// Test method EuclidClassic with two params
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <param name="rezalt">expected result</param>
        [TestCase(12, 30, 6)]
        [TestCase(0, 6, 6)]
        [TestCase(12, -30, 6)]
        [TestCase(42, 86, 2)]
        public void EuclidClassic_With_Two_Params(int first, int second, int rezalt)
        {
            Assert.AreEqual(AlgorithmsForTasks.EuclidClassic(first, second), rezalt);
        }

        /// <summary>
        /// Test method EuclidBinary with two params
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <param name="rezalt">expected result</param>
        [TestCase(12, 30, 6)]
        [TestCase(0, 6, 6)]
        [TestCase(12, -30, 6)]
        [TestCase(42, 86, 2)]
        public void EuclidBinary_With_Two_Params(int first, int second, int rezalt)
        {
            Assert.AreEqual(AlgorithmsForTasks.EuclidBinary(first, second), rezalt);
        }

        /// <summary>
        /// Test method EuclidClassic with two params
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <param name="third">third parametr</param>
        /// <param name="rezalt">expected result</param>
        [TestCase(12, 30, 24, 6)]
        [TestCase(0, 30, 24, 6)]
        [TestCase(12, -30, 24, 6)]
        [TestCase(42, 86, 24, 2)]
        public void EuclidClassic_With_Three_Params(int first, int second, int third, int rezalt)
        {
            Assert.AreEqual(AlgorithmsForTasks.EuclidClassic(first, second, third), rezalt);
        }

        /// <summary>
        /// Test method EuclidBinary with three params
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <param name="third">third parametr</param>
        /// <param name="rezalt">expected result</param>
        [TestCase(12, 30, 24, 6)]
        [TestCase(0, 30, 24, 6)]
        [TestCase(12, -30, 24, 6)]
        [TestCase(42, 86, 24, 2)]
        public void EuclidBinary_With_Three_Params(int first, int second, int third, int rezalt)
        {
            Assert.AreEqual(AlgorithmsForTasks.EuclidBinary(first, second, third), rezalt);
        }

        /// <summary>
        /// Test method EuclidMethods with valid data and method EuclidForTwoNumbers
        /// </summary>
        /// <param name="rezalt">expected result</param>
        /// <param name="inputData">input data</param>
        [TestCase(6, 12, 30, 24)]
        [TestCase(6, 0, 30, 24)]
        [TestCase(6, 12, -30, 24)]
        [TestCase(2, 42, 86)]
        public void EuclidClassic_With_Array_Params(int rezalt, params int[] inputData)
        {
            Assert.AreEqual(AlgorithmsForTasks.EuclidClassic(inputData), rezalt);
        }

        /// <summary>
        /// Test method EuclidMethods with valid data and BinaryAlgorithmOfEuclid
        /// </summary>
        /// <param name="rezalt">expected result</param>
        /// <param name="inputData">input data</param>
        [TestCase(6, 12, 30, 24)]
        [TestCase(6, 0, 30, 24)]
        [TestCase(6, 12, -30, 24)]
        [TestCase(2, 42, 86)]
        public void EuclidMethods_With_Valid_Data_BinaryAlgorithmOfEuclid(int rezalt, params int[] inputData)
        {
            Assert.AreEqual(AlgorithmsForTasks.EuclidBinary(inputData), rezalt);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method EuclidClassic if the referenced array reference refers to null.
        /// </summary>
        [TestCase(null)]
        public void EuclidClassic_If_Input_Array_Length_Is_null(int[] inputArray)
        {
            Assert.Throws<ArgumentNullException>(() => AlgorithmsForTasks.EuclidClassic(inputArray));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method EuclidClassic if the referenced array reference refers 
        /// to array with 0 element
        /// </summary>
        [TestCase(new int[0])]
        [TestCase(new int[1] { 2 })]
        public void EuclidClassic_If_Input_Array_Null(int[] inputArray)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTasks.EuclidClassic(inputArray));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method EuclidBinary if the referenced array reference refers to null.
        /// </summary>
        [TestCase(null)]
        public void EuclidBinary_If_Input_Array_Length_Is_null(int[] inputArray)
        {
            Assert.Throws<ArgumentNullException>(() => AlgorithmsForTasks.EuclidBinary(inputArray));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method EuclidBinary if the referenced array reference refers 
        /// to array with 0 element
        /// </summary>
        [TestCase(new int[0])]
        [TestCase(new int[1] { 2 })]
        public void EuclidBinary_If_Input_Array_Null(int[] inputArray)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTasks.EuclidBinary(inputArray));
        }
    }
}
