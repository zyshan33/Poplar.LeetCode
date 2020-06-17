# 移动零

## leet code 地址
中文 https://leetcode-cn.com/problems/move-zeroes<br/>
英文 https://leetcode.com/problems/move-zeroes

## 双指针
```
    public void MoveZeroes(int[] nums)
    {
        int index = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[index] = nums[i];
                if (i != index)
                {
                    nums[i] = 0;
                }
                index++;
            }
        }
    }
```
时间复杂度是O(n)。<br/>
定义一个指针"index"并且初始化为零，它的定义为最左边为零的数字，最开始的时候，不管最左边的值是否为零，接下来开始循环<br/>
第一次循环，判断当前遍历的数是否为零：<br/>
&emsp;&emsp;如果不为零，则将nums[index]的值替换为nums[i]的值，此时i和index值相等，所以直接将index值自增1。<br/>
&emsp;&emsp;如果为零，则不进行任何操作，此时index的值还是为零，并且它的值是最左边为零的数的索引，也就是零。<br/>
第二次循环，同样判断当前遍历的数是否为零：<br/>
&emsp;&emsp;如果不为零，则将nums[index]的值替换为nums[i]的值，此时判断i和index值是否相等，如果不相等，结合第一步的操作，就发现index是指向最左边为零的数的索引，因为已经将nums[index]的值替换为nums[i]了，所以此时将nums[i]的值替换为零，也就是将"0"向右移1为，最后index自增1，从新指向最左边为零的数。
&emsp;&emsp;如果为零，不进行任何操作，进入下入一个循环。<br/>
第三次循环和第二次循环类似，一直执行下去，直到整个数组被遍历完。
