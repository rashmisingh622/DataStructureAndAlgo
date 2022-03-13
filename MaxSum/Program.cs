using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSum
{
    class Program
    {
        public int maxSum = 0;
        public int GetMaxSubArray(int[] array, int start, int currentSum)
        {
            if (start == array.Length - 1)
            {
                return Math.Max(maxSum, currentSum + array[start]);
            }

            currentSum += array[start];
            return Math.Max(maxSum, GetMaxSubArray(array, start + 1, currentSum));
        }

        public int GetMaxSubArray(int[] array)
        {
            // sum += currentElement
            // start = 0
            // end = 0 to length - 1
            // from (start to end) => sum
            // sum < maxSum => start => start + 1; currentSum = 0
            var sum = 0;
            var maxSum = 0;
            var start = 0;
            int[] sumArray = new int[array.Length];
            for (int end = 0; end < array.Length; end++)
            {
                sum += array[end];
                maxSum = Math.Max(maxSum, sum);
                if (sum < 0)
                {
                    start = end + 1;
                    sum = 0;
                }
            }

            return maxSum;
        }

        public int[] CountBits(int n, int[] resultArray, int final)
        {
            var currNum = n;
            var countBits = 0;

            if (currNum > final)
            {
                return resultArray;
            }

            if (currNum == 1)
            {
                resultArray[1] = 1;
            }

            if (currNum == 0)
            {
                resultArray[0] = 0;
            }

            if (currNum > 1)
            {
                while (currNum >= 1)
                {
                    if (currNum % 2 == 1)
                    {
                        countBits++;
                    }

                    currNum = currNum / 2;
                }
                resultArray[n] = countBits;
            }

            CountBits(n + 1, resultArray, final);
            return resultArray;
        }

        public int NumberOfArithmeticSlices(int[] nums)
        {
            var length = nums.Length;
            if (nums.Length <= 2)
            {
                return 0;
            }
            var start = 0;
            var diff = nums[1] - nums[0];
            var result = 0;
            for (int end = 2; end < length;)
            {
                if (nums[end] - nums[end - 1] == diff)
                {
                    end++;
                }
                else if (nums[end] - nums[end - 1] != diff)
                {
                    result += getCountSubArray(nums, start, end - 1);
                    start = end - 1;
                    diff = nums[end] - nums[end - 1];
                }
            }

            return result + getCountSubArray(nums, start, length - 1);
        }

        public int getCountSubArray(int[] arr, int start, int end)
        {
            if (end - start < 2)
            {
                return 0;
            }

            var num = end - start - 1;
            return num * (num + 1) / 2;
        }

        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            // total glasses until query_row
            double totalGlasses = (query_row + 1) * (query_row + 1 + 1) / 2;

            double totalGlassesBeforeQueryRow = (query_row) * (query_row + 1) / 2;
            double result = 0;
            if (poured >= totalGlasses)
            {
                result = 1;
                return result;
            }

            if (poured <= totalGlassesBeforeQueryRow)
            {
                result = 0;
                return result;
            }

            double difference = poured - totalGlassesBeforeQueryRow;
            double numberOfGlassesInCurrentRow = query_row + 1;

            double numberOfGlassesInPreviousRow = query_row;
            double totalStreams = numberOfGlassesInPreviousRow * 2;
            double liquidFromEachStream = difference / totalStreams;

            if (query_glass == 0 || query_glass == query_row)
            {
                result = liquidFromEachStream;
                return result;
            }
            else
            {
                result = liquidFromEachStream * 2;
                return result;
            }
        }

        static void Main(string[] args)
        {
            //var array = new int[6] { -1, -2, 4, 5, -2, 10 };
            //var p = new Program();
            //var maxSum = p.GetMaxSubArray(array);

            //var array = new int[] { 1, 2, 3, 8, 9, 10 };
            var p = new Program();
            //var maxSum = p.NumberOfArithmeticSlices(array);
            var result1 = p.ChampagneTower(25, 6, 1);
            int[] resultArray = new int[3];
            var result = p.CountBits(0, resultArray, 2);
            //Console.WriteLine($"The max Sum: {maxSum}");
            Console.ReadLine();
        }
    }
}
