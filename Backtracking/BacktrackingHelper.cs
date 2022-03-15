using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    public class BacktrackingHelper
    {
        public void PrintNum(int n)
        {
            if (n == 6)
            {
                return;
            }

            Console.WriteLine(n);

            PrintNum(n + 1);
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();

            return list;
        }

        public IList<IList<int>> Permute(int[] nums, int i, IList<IList<int>> result)
        {
            if (i == nums.Length - 1)
            {
                result.Add(new List<int> { nums[i] });
            }
        }
    }
}
