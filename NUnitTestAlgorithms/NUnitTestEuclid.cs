using System;
using NUnit.Framework;
using Algorithms;
using System.Linq;

namespace NUnitTestAlgorithms
{
    [TestFixture]
    public class NUnitTestEuclid
    {
        [TestCase(6, 12, 30, 24)]
        [TestCase(6, 0, 30, 24)]
        [TestCase(6, 12, -30, 24)]
        [TestCase(2, 42, 86)]
        public void NUnitTestAlgorithmOfEuclid_With_Valid_Data(int rezalt, params int[] inputData)
            => Assert.AreEqual(AlgorithmsMethods.AlgorithmOfEuclidForNumbers(inputData), rezalt);

        [TestCase(6, 12, 30, 24)]
        [TestCase(6, 0, 30, 24)]
        [TestCase(6, 12, -30, 24)]
        [TestCase(2, 42, 86)]
        public void NUnitTestBinaryAlgorithmOfEuclid_With_Valid_Data(int rezalt, params int[] inputData)
            => Assert.AreEqual(AlgorithmsMethods.BinaryAlgorithmOfEuclidForNumbers(inputData), rezalt);

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method AlgorithmOfEuclidForNumbers if the referenced array reference refers to null.
        /// </summary>
        [Test]
        public void NUnitTestAlgorithmOfEuclid_If_Input_Array_Is_Null()
        {
            int [] _inputArray = null;

            Assert.Throws<ArgumentNullException>(() => AlgorithmsMethods.AlgorithmOfEuclidForNumbers(_inputArray));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method AlgorithmOfEuclidForNumbers if the referenced array reference refers to array with 0 element.
        /// </summary>
        [Test]
        public void NUnitTestAlgorithmOfEuclid_If_Input_Array_Length_Is_0()
        {
            int[] _inputArray = new int[0];

            Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsMethods.AlgorithmOfEuclidForNumbers(_inputArray));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method AlgorithmOfEuclidForNumbers if the referenced array reference refers to array with 1 element.
        /// </summary>
        [Test]
        public void NUnitTestAlgorithmOfEuclid_If_Input_Array_Length_Is_1()
        {
            int[] _inputArray = new int[1];

            Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsMethods.AlgorithmOfEuclidForNumbers(_inputArray));
        }

    }
}
