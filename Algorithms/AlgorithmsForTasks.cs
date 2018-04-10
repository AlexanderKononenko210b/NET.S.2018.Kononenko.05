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

        #region EuclidPublicApi

        /// <summary>
        /// Method calculate greatest common divisor two params type int using method EuclidForTwoNumbers
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidClassic(int first, int second) => ClassicEuclidAlgorithm(first, second);

        /// <summary>
        /// Method calculate greatest common divisor two params type int using method BinaryAlgorithmOfEuclid
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidBinary(int first, int second) => BinaryEuclidAlgorithm(first, second);

        /// <summary>
        /// Method calculate greatest common divisor three params type int using method EuclidForTwoNumbers
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <param name="third">third parametr</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidClassic(int first, int second, int third)
            => ApproachThreeParams(ClassicEuclidAlgorithm, first, second, third);

        /// <summary>
        /// Method calculate greatest common divisor three params type int using method BinaryAlgorithmOfEuclid
        /// </summary>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <param name="third">third parametr</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidBinary(int first, int second, int third)
            => ApproachThreeParams(BinaryEuclidAlgorithm, first, second, third);

        /// <summary>
        /// Method calculate greatest common divisor array params using method EuclidForTwoNumbers
        /// </summary>
        /// <param name="inputArray">input array params</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidClassic(params int[] inputArray)
            => ApproachArrayParams(ClassicEuclidAlgorithm, inputArray);

        /// <summary>
        /// Method calculate greatest common divisor array params using method BinaryAlgorithmOfEuclid
        /// </summary>
        /// <param name="inputArray">input array params</param>
        /// <returns>greatest common divisor</returns>
        public static int EuclidBinary(params int[] inputArray)
            => ApproachArrayParams(BinaryEuclidAlgorithm, inputArray);

        #endregion EuclidPublicApi

        #region EuclidApproachs

        /// <summary>
        /// Approach Euclid for three parameters
        /// </summary>
        /// <param name="delegat">delegat incapsulating method for calc greatest common divisor</param>
        /// <param name="first">first parametr</param>
        /// <param name="second">second parametr</param>
        /// <param name="third">third parametr</param>
        /// <returns>greatest common divisor</returns>
        private static int ApproachThreeParams(Func<int, int, int> delegat, int first, int second, int third)
        {
            var firstResult = delegat(first, second);

            return delegat(firstResult, third);
        }

        /// <summary>
        /// Approach Euclid for array params
        /// </summary>
        /// <param name="delegat">delegat incapsulating method for calc greatest common divisor</param>
        /// <param name="inputArray">input array params</param>
        /// <returns>greatest common divisor</returns>
        private static int ApproachArrayParams(Func<int, int, int> delegat, params int[] inputArray)
        {
            VerifyArray(inputArray);

            var arrayForWork = new int[inputArray.Length];

            arrayForWork = (int[])inputArray.Clone();

            if(arrayForWork == null)
            {
                throw new InvalidCastException($"Operation clon from argument {nameof(inputArray)} is invalid");
            }

            var depth = 0;

            do
            {
                arrayForWork[depth + 1] = delegat(arrayForWork[depth], arrayForWork[depth + 1]);

                depth++;
            }
            while (depth != arrayForWork.Length - 1);

            return arrayForWork[arrayForWork.Length - 1];
        }

        #endregion

        #region EuclidAlgorithms

        /// <summary>
        /// Classic Euclid algorithm for find greatest common divisor
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>greatest common divisor</returns>
        public static int ClassicEuclidAlgorithm(int firstNumber, int secondNumber)
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

        /// <summary>
        /// Binary Euclid`s method for find greatest common divisor
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>greatest common divisor</returns>
        public static int BinaryEuclidAlgorithm(int firstNumber, int secondNumber)
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

        #endregion EuclidAlgorithms

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
        /// Method for verify input Array type int
        /// </summary>
        /// <param name="inputArray">input array</param>
        private static void VerifyArray(params int[] inputArray)
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
        }

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
