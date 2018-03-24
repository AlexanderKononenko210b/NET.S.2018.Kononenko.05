using System;
using NUnit.Framework;
using Algorithms;
using System.Linq;

namespace NUnitTestAlgorithms
{
    /// <summary>
    /// Test class for methods 
    /// </summary>
    [TestFixture]
    public class Euclid
    {
        /// <summary>
        /// Test method EuclidForNumbers with valid data
        /// </summary>
        /// <param name="rezalt">expected result</param>
        /// <param name="inputData">input data</param>
        [TestCase(6, 12, 30, 24)]
        [TestCase(6, 0, 30, 24)]
        [TestCase(6, 12, -30, 24)]
        [TestCase(2, 42, 86)]
        public void Euclid_With_Valid_Data(int rezalt, params int[] inputData)
            => Assert.AreEqual(AlgorithmsMethods.EuclidForNumbers(inputData), rezalt);

        /// <summary>
        /// Test method BinaryEuclid with valid data
        /// </summary>
        /// <param name="rezalt">expected result</param>
        /// <param name="inputData">input data</param>
        [TestCase(6, 12, 30, 24)]
        [TestCase(6, 0, 30, 24)]
        [TestCase(6, 12, -30, 24)]
        [TestCase(2, 42, 86)]
        public void BinaryEuclid_With_Valid_Data(int rezalt, params int[] inputData)
            => Assert.AreEqual(AlgorithmsMethods.BinaryEuclid(inputData), rezalt);

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method AlgorithmOfEuclidForNumbers if the referenced array reference refers to null.
        /// </summary>
        [TestCase(null)]
        public void EuclidForNumbers_If_Input_Array_Length_Is_0_And_1(int[] inputArray)
            => Assert.Throws<ArgumentNullException>(() => AlgorithmsMethods.EuclidForNumbers(inputArray));

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method AlgorithmOfEuclidForNumbers if the referenced array reference refers 
        /// to array with 0 element
        /// </summary>
        [TestCase(new int[0])]
        [TestCase(new int[1] { 2 })]
        public void EuclidForNumbers_If_Input_Array_Null(int[] inputArray)
            => Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsMethods.EuclidForNumbers(inputArray));
    }
}
