# 爬楼梯

## leet code 地址
中文 https://leetcode-cn.com/problems/climbing-stairs<br/>
英文 https://leetcode.com/problems/climbing-stairs

### 解题思路
当台阶只有 1 级的时候，只能是跨 1 步，就到终点，也就是 1 种解法。<br/>
当台阶有 2 级的时候，第一步可以选择跨 1 步或者跨 2 步，如果跨 2 步，就直接到终点，跨 1 步，那就还有剩下 1 步，所以解法是 2 种。<br/>
当台阶有 3 级的时候，第一步可以选择跨 1 步或者跨 2 步，所以 3 级台阶的解法是“跨 1 步后剩下级数的解法”加上“跨 2 步后剩下级数的解法”。
此时可以得到公式f(n) = f(n - 1) + f(n - 2)，也就变成了经典的斐波那契数列。

### 递归方式
```
    public int ClimbStairs(int n)
    {
        if (n < 3)
        {
            return n;
        }
        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }
```
```
    private int[] _cache;
    public int ClimbStairs(int n)
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
            this._cache[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }
        return this._cache[n];
    }
```
上面两种方法都是递归，第一种是普通递归，第二种是带缓存的递归，将计算过的f(n)的值缓存起来，下次再递归到f(n)的时候，直接返回，避免重复的递归计算。

### 动态规划
```
    //时间复杂度是O(n)，空间复杂度是O(n)
    public int ClimbStairs(int n)
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
```
```
    //时间复杂度是O(n)，空间复杂度是O(1)
    public int ClimbStairs(int n)
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
```
根据上面解题思路的公式f(n) = f(n - 1) + f(n - 2)， 可以得到一个dp方程：<br/>
&emsp;&emsp;假设有f[i]，代表当n等于i时，爬到终点的方法数，则f[i] = f[i - 1] + f[i - 2]，也就是动态规划里的第一种解法。<br/>
&emsp;&emsp;动态规划里的第二种解法，是对第一种解法的优化，省去了额外的O(n)的时间复杂度。它用两个变量n1、n2分别代表f[i - 2]、f[i - 1]的值，每次循环的时候，将n2的值替换为f[i]，将n1的值替换为n2。
