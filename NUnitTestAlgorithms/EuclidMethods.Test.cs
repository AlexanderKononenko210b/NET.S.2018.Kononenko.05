using System;
using NUnit.Framework;
using Algorithms;

namespace NUnitTestAlgorithms
{
	[TestFixture]
	public class EuclidMethods
	{
        /// <summary>
        /// Test method EuclidMethods with valid data and method EuclidForTwoNumbers
        /// </summary>
        /// <param name="rezalt">expected result</param>
        /// <param name="inputData">input data</param>
        [TestCase(6, 12, 30, 24)]
        [TestCase(6, 0, 30, 24)]
        [TestCase(6, 12, -30, 24)]
        [TestCase(2, 42, 86)]
        public void EuclidMethods_With_Valid_Data_EuclidForTwoNumbers(int rezalt, params int[] inputData)
        {
            AlgorithmsForTasks.EuclidDelegate delegateEuclid = new AlgorithmsForTasks.EuclidDelegate(AlgorithmsForTasks.EuclidForTwoNumbers);

            Assert.AreEqual(AlgorithmsForTasks.EuclidMethods(delegateEuclid, inputData), rezalt);
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
            AlgorithmsForTasks.EuclidDelegate delegateEuclid = new AlgorithmsForTasks.EuclidDelegate(AlgorithmsForTasks.BinaryAlgorithmOfEuclid);

            Assert.AreEqual(AlgorithmsForTasks.EuclidMethods(delegateEuclid, inputData), rezalt);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method EuclidMethods if the referenced array reference refers to null.
        /// </summary>
        [TestCase(null)]
        public void EuclidMethods_If_Input_Array_Length_Is_0_And_1(int[] inputArray)
        {
            AlgorithmsForTasks.EuclidDelegate delegateEuclid = new AlgorithmsForTasks.EuclidDelegate(AlgorithmsForTasks.BinaryAlgorithmOfEuclid);

            Assert.Throws<ArgumentNullException>(() => AlgorithmsForTasks.EuclidMethods(delegateEuclid, inputArray));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method EuclidMethods if the referenced array reference refers 
        /// to array with 0 element
        /// </summary>
        [TestCase(new int[0])]
        [TestCase(new int[1] { 2 })]
        public void EuclidMethods_If_Input_Array_Null(int[] inputArray)
        {
            AlgorithmsForTasks.EuclidDelegate delegateEuclid = new AlgorithmsForTasks.EuclidDelegate(AlgorithmsForTasks.BinaryAlgorithmOfEuclid);

            Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTasks.EuclidMethods(delegateEuclid, inputArray));
        }
    }
}
