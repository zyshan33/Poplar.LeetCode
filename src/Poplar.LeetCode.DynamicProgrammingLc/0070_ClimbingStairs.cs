using System;
using System.Collections.Generic;
using System.Text;

namespace Poplar.LeetCode.DynamicProgrammingLc
{
    /// <summary>
    /// https://leetcode-cn.com/problems/climbing-stairs/
    /// https://leetcode.com/problems/climbing-stairs/
    /// 当台阶只有 1 级的时候，只能是跨 1 步，就到终点，也就是 1 种解法。
    /// 当台阶有 2 级的时候，第一步可以选择跨 1 步或者跨 2 步，如果跨 2 步，就直接到终点，跨 1 步，那就还有剩下 1 步，所以解法是 2 种。
    /// 当台阶有 3 级的时候，第一步可以选择跨 1 步或者跨 2 步，所以 3 级台阶的解法是“跨 1 步后剩下级数的解法”加上“跨 2 步后剩下级数的解法”。
    /// 此时可以得到公式f(n) = f(n - 1) + f(n - 2)，也就变成了经典的斐波那契数列。
    /// </summary>
    public class ClimbingStairsLc
    {
        /// <summary>
        /// 普通递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairsOne(int n)
        {
            if (n < 3)
            {
                return n;
            }
            return ClimbStairsOne(n - 1) + ClimbStairsOne(n - 2);
        }

        private int[] _cache;
        /// <summary>
        /// 带缓存的递归，将计算过的f(n)的值缓存起来，下次再递归到f(n)的时候，直接返回，避免重复的递归计算。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairsTwo(int n)
        {
            if (n < 3)
            {
                return n;
            }
            if (_cache == null)
            {
                this._cache = new int[n + 1];
                this._cache[1] = 1;
                this._cache[2] = 2;
            }
            if (this._cache[n] == 0)
            {
                this._cache[n] = ClimbStairsTwo(n - 1) + ClimbStairsTwo(n - 2);
            }
            return this._cache[n];
        }

        /// <summary>
        /// 根据上面解题思路的公式f(n) = f(n - 1) + f(n - 2)， 可以得到一个dp方程：
        /// 假设有f[i]，代表当n等于i时，爬到终点的方法数，则f[i] = f[i - 1] + f[i - 2]，也就是动态规划里的第一种解法。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairsThree(int n)
        {
            if (n < 3)
            {
                return n;
            }
            var arr = new int[n + 1];
            arr[1] = 1;
            arr[2] = 2;
            for (var i = 3; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n];
        }

        /// <summary>
        /// <summary>
        /// 根据上面解题思路的公式f(n) = f(n - 1) + f(n - 2)， 可以得到一个dp方程：
        /// 假设有f[i]，代表当n等于i时，爬到终点的方法数，则f[i] = f[i - 1] + f[i - 2]，也就是动态规划里的第一种解法。
        /// 省去了额外的O(n)的时间复杂度。它用两个变量n1、n2分别代表f[i - 2]、f[i - 1] 的值，每次循环的时候，将n2的值替换为f[i]，将n1的值替换为n2。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairsFour(int n)
        {
            if (n < 3)
            {
                return n;
            }
            var n1 = 1;
            var n2 = 2;
            for (var i = 3; i <= n; i++)
            {
                var temp = n2;
                n2 = n1 + n2;
                n1 = temp;
            }
            return n2;
        }
    }
}
