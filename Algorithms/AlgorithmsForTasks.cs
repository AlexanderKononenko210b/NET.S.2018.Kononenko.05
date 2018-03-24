using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Algorithms
{
    /// <summary>
    /// Class performance algorithms
    /// </summary>
    public static class AlgorithmsForTasks
    {
        const int BIT_IN_BYTE = 8;

        #region Euclid

        /// <summary>
        /// Method for finding the GCD of integers by the classical Euclidean method
        /// </summary>
        /// <param name="inputArray">input numbers</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidForNumbers(params int [] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            if (inputArray.Length == 1)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length to be more than 1");
            }

            var depth = 0;

            do
            {
                inputArray[depth + 1] = EuclidForTwoNumbers(ref inputArray[depth], ref inputArray[depth + 1]);

                depth++;
            }
            while (depth != inputArray.Length - 1);

            return inputArray[inputArray.Length - 1];
        }

        /// <summary>
        /// Classic Euclid algorithm for find greatest common divisor
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidForTwoNumbers(ref int firstNumber, ref int secondNumber)
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

        #endregion Euclid

        #region BinaryEuclid

        /// <summary>
        /// Method for finding the greatest common divisor of integers by the classical Euclidean method
        /// </summary>
        /// <param name="inputArray">input numbers</param>
        /// <returns>greatest common divisor</returns>
        public static int BinaryEuclid(params int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            if (inputArray.Length == 1)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length to be more than 1");
            }

            var depth = 0;

            do
            {
                inputArray[depth + 1] = BinaryAlgorithmOfEuclid(inputArray[depth], inputArray[depth + 1]);

                depth++;
            }
            while (depth != inputArray.Length - 1);

            return inputArray[inputArray.Length - 1];
        }

        /// <summary>
        /// Binary Euclid`s method for find greatest common divisor
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>greatest common divisor</returns>
        public static int BinaryAlgorithmOfEuclid(int firstNumber, int secondNumber)
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

        #endregion BinaryEuclid

        #region FormatterDoubleToBinary

        /// <summary>
        /// Method for formatter number type double in to the number formatter binary
        /// </summary>
        /// <param name="inputNumberWithDoublePoint">source number</param>
        /// <returns>bunary number in string performance</returns>
        public static string FormatterDoubleToBinary(this double inputNumberWithDoublePoint)
        {
            var structForFormatter = new DoubleToLongStruct { DoubleTo8Byte = inputNumberWithDoublePoint };

            var valueToBinary = structForFormatter.LongTo8Byte;

            var lengthResult = sizeof(long) * BIT_IN_BYTE;

            var reversResult = lengthResult;

            var resultArray = new StringBuilder();

            for (int i = 0; i < lengthResult; i++)
            {
                var addNumber = ((valueToBinary & (1L << reversResult - 1)) == 0) ? (byte)0 : (byte)1;

                resultArray.Append(((valueToBinary & (1L << reversResult - 1)) == 0) ? (byte)0 : (byte)1);

                reversResult--;
            }

            return resultArray.ToString();
        }

        /// <summary>
        /// Private helper struct for the perfomance base system input number
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long longTo8Byte;

            [FieldOffset(0)]
            private double doubleTo8Byte;

            public double DoubleTo8Byte
            {
                get { return doubleTo8Byte; }
                set { doubleTo8Byte = value; }
            }

            public long LongTo8Byte
            {
                get { return longTo8Byte; }
            }
        }

        #endregion Formatter

        # region FormatterStringToInt

        /// <summary>
        /// Method for formatter number in string performance 
        /// </summary>
        /// <param name="inputString">input string</param>
        /// <param name="base">base system number</param>
        /// <returns>int perfomance</returns>
        public static int FormatterStringToInt(this string inputString, int @base)
        {
            if(string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentException($"Input string nameof {inputString} is not valid");
            }

            var inputStringToUpper = inputString.ToUpper();

            var notation = new Notation(@base);

            var resultNumber = 0;

            var degreeToBase = 1;

            for (int i = inputStringToUpper.Length - 1; i >= 0; i--)
            {
                var indexSearch = notation.Alphabet.IndexOf(inputStringToUpper[i]);

                if (indexSearch < 0 || indexSearch > @base)
                {
                    throw new ArgumentException($"Input string does not have base as {notation.Base}");
                }

                    resultNumber += indexSearch * degreeToBase;

                checked
                {
                    if (i != 0)
                        degreeToBase *= notation.Base;
                }
            }

            return resultNumber;
        }

        /// <summary>
        /// Helper class describing system number base
        /// </summary>
        public class Notation
        {
            const string ALFABET_SOURCE = "0123456789ABCDEF";

            const int START_BASE_BORDER = 0;

            const int END_BASE_BORDER = 16;

            private int @base;

            public int Base
            {
                get { return @base; }

                set
                {
                    if (value < START_BASE_BORDER || value > END_BASE_BORDER)
                    {
                        throw new ArgumentException($"Arguments nameof {value} is not valid");
                    }
                    else
                    {
                        @base = value;
                    }
                }
            }

            public string Alphabet { get; private set; }

            public Notation(int inputBase)
            {
                Base = inputBase;

                Alphabet = ALFABET_SOURCE.Substring(0, Base);
            }
        }

        #endregion FormatterStringToInt

        #region Helper

        /// <summary>
        /// Method for test method AlgorithmOfEuclidForNumbers
        /// </summary>
        /// <param name="nod">nod after calculate</param>
        /// <param name="inputArray">input bunch</param>
        /// <returns>true if result dune and false if not dune</returns>
        public static bool AlgorithmOfEuclidForNumbersHelper(int nod, params int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if(inputArray[i] % nod == 0)
                    return false;
            }

            return true;
        }

        #endregion Helper
    }
}
