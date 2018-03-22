using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class AlgorithmsMethods
    {
        #region EuclidMethods

        /// <summary>
        /// Method for finding the GCD of integers by the classical Euclidean method
        /// </summary>
        /// <param name="inputBunch">input numbers</param>
        /// <returns>greatest common divisor</returns>
        public static int AlgorithmOfEuclidForNumbers(params int [] inputBunch)
        {
            if (inputBunch == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputBunch)} is null");
            }

            if (inputBunch.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputBunch)} length is 0");
            }

            if (inputBunch.Length == 1)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputBunch)} length to be more than 1");
            }

            for(int i = 0; i < inputBunch.Length; i++)
            {
                ValidateNumberTypeInt(inputBunch[i]);
            }

            var depth = 0;

            do
            {
                inputBunch[depth + 1] = AlgorithmOfEuclid(ref inputBunch[depth], ref inputBunch[depth + 1]);

                depth++;
            }
            while (depth != inputBunch.Length - 1);

            return inputBunch[inputBunch.Length - 1];
        }

        /// <summary>
        /// Classic Euclid algorithm for find greatest common divisor
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>greatest common divisor</returns>
        public static int AlgorithmOfEuclid(ref int firstNumber, ref int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);

            secondNumber = Math.Abs(secondNumber);

            while (firstNumber != 0 & secondNumber != 0)
            {
                if (firstNumber > secondNumber)
                    firstNumber %= secondNumber;
                else
                    secondNumber %= firstNumber;
            }
            return (firstNumber == 0) ? secondNumber : firstNumber;
        }

        #endregion EuclidMethods

        #region BinaryEuclidMethods

        /// <summary>
        /// Method for finding the greatest common divisor of integers by the classical Euclidean method
        /// </summary>
        /// <param name="inputBunch">input numbers</param>
        /// <returns>greatest common divisor</returns>
        public static int BinaryAlgorithmOfEuclidForNumbers(params int[] inputBunch)
        {
            if (inputBunch == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputBunch)} is null");
            }

            if (inputBunch.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputBunch)} length is 0");
            }

            if (inputBunch.Length == 1)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputBunch)} length to be more than 1");
            }

            for (int i = 0; i < inputBunch.Length; i++)
            {
                ValidateNumberTypeInt(inputBunch[i]);
            }

            var depth = 0;

            do
            {
                inputBunch[depth + 1] = BinaryAlgorithmOfEuclid(ref inputBunch[depth], ref inputBunch[depth + 1]);

                depth++;
            }
            while (depth != inputBunch.Length - 1);

            return inputBunch[inputBunch.Length - 1];
        }

        /// <summary>
        /// Binary Euclid`s method for find greatest common divisor
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>greatest common divisor</returns>
        public static int BinaryAlgorithmOfEuclid(ref int firstNumber, ref int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);

            secondNumber = Math.Abs(secondNumber);

            var offset = 0;

            if (firstNumber == 0 || secondNumber == 0)
            {
                return firstNumber | secondNumber;
            }

            while (((firstNumber | secondNumber) & 1) == 0)
            {
                offset++;

                firstNumber >>= 1;

                secondNumber >>= 1;
            }

            while ((firstNumber & 1) == 0)
            {
                firstNumber >>= 1;
            }

            do
            {
                while ((secondNumber & 1) == 0)
                {
                    secondNumber >>= 1;
                }

                if (firstNumber < secondNumber)
                {
                    secondNumber -= firstNumber;
                }
                else
                {
                    var helper = firstNumber - secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = helper;
                }

                secondNumber >>= 1;
            }
            while (secondNumber != 0);

            return firstNumber << offset;
        }

        #endregion BinaryEuclidMethods

        #region Helper

        /// <summary>
        /// Method for validate number type int
        /// </summary>
        /// <param name="numberArrayForValidate">array params type int</param>
        public static void ValidateNumberTypeInt(params int[] numberArrayForValidate)
        {
            for (int i = 0; i < numberArrayForValidate.Length; i++)
            {
                if (numberArrayForValidate[i] < int.MinValue || numberArrayForValidate[i] > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException($"Argument`s with index {i} is not valid");
                }
            }
        }

        /// <summary>
        /// Method for test method AlgorithmOfEuclidForNumbers
        /// </summary>
        /// <param name="nod">nod after calculate</param>
        /// <param name="inputBunch">input bunch</param>
        /// <returns></returns>
        public static bool AlgorithmOfEuclidForNumbersHelper(int nod, params int[] inputBunch)
        {
            int flagSuccessful = 0;

            for (int i = 0; i < inputBunch.Length; i++)
            {
                if(inputBunch[i] % nod == 0)
                    flagSuccessful++;
            }

            return flagSuccessful == inputBunch.Length;
        }

        #endregion Helper
    }
}
