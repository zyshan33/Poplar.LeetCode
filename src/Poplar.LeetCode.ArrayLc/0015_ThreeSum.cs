using System;
using System.Collections.Generic;

namespace Poplar.LeetCode.ArrayLc
{
    /// <summary>
    /// 三数之和
    /// https://leetcode.com/problems/3sum/
    /// https://leetcode-cn.com/problems/3sum/
    /// </summary>
    public class ThreeSumLc
    {
        /// <summary>
        /// 这个题要求返回的集合中不包含重复的集合，又因为数组中可能包含重复的元素，所以使用简单的三重循环无法达到题目的要求，如果还是想使用简单的三重循环，那么循环本身的时间复杂度是O(n³)，还需要进行复杂的去重操作。
        /// 避免进行去重操作，可以先对数组进行排序，此时三层循环里就满足a ≤ b ≤ c，我们就可以在每层循环中分别对a、b、c进行去重操作，这样的时间复杂度是O(n³)。
        /// 加速的方式是使用两层循环，对内层循环中使用双指针。
        /// 外层循环从数组左边出发，假设外层循环索引为i，那么i从零出发。
        /// 内层循环中的左指针left = i + 1，right = nums.Length - 1。此时我们计算三个数的合。
        /// 如果结果大于零，则证明right指向的数字大了，需要往左边移动一位。
        /// 如果结果小于零，则证明left指向的数字小了，需要往右边移动一位。
        /// 如果结果等于零，则证明正好，将当前三个数放到结果集中，此时因为结果集不能重复，所以需要将left指针往左移1位，right指针往右移一位，然后再进行两个子循环，将left指针和right指针都移动到和上个值不相等的地方。
        /// 这个方法的时间复杂度是O(n²)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var container = new List<IList<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    var left = i + 1;
                    var right = nums.Length - 1;
                    while (left < right)
                    {
                        var sum = nums[i] + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            container.Add(new List<int>() { nums[i], nums[left++], nums[right--] });
                            while (left < right && nums[left] == nums[left - 1])
                            {
                                left++;
                            }
                            while (left < right && nums[right] == nums[right + 1])
                            {
                                right--;
                            }
                        }
                        else if (sum < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }
            return container;
        }
    }
}
