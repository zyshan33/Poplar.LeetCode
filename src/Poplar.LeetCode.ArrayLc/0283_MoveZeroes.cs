namespace Poplar.LeetCode.ArrayLc
{
    /// <summary>
    /// 移动零
    /// https://leetcode.com/problems/move-zeroes
    /// https://leetcode-cn.com/problems/move-zeroes
    /// </summary>
    public class MoveZeroesLc
    {
        /// <summary>
        /// 时间复杂度是O(n)。<br/>
        /// 定义一个指针"index"并且初始化为零，它的定义为最左边为零的数字，最开始的时候，不管最左边的值是否为零，接下来开始循环<br/>
        /// 第一次循环，判断当前遍历的数是否为零：<br/>
        /// 如果不为零，则将nums[index] 的值替换为nums[i]的值，此时i和index值相等，所以直接将index值自增1。<br/>
        /// 如果为零，则不进行任何操作，此时index的值还是为零，并且它的值是最左边为零的数的索引，也就是零。<br/>
        /// 第二次循环，同样判断当前遍历的数是否为零：<br/>
        /// 如果不为零，则将nums[index] 的值替换为nums[i]的值，此时判断i和index值是否相等，如果不相等，结合第一步的操作，就发现index是指向最左边为零的数的索引，因为已经将nums[index] 的值替换为nums[i]了，所以此时将nums[i] 的值替换为零，也就是将"0"向右移1为，最后index自增1，从新指向最左边为零的数。
        /// 如果为零，不进行任何操作，进入下入一个循环。<br/>
        /// 第三次循环和第二次循环类似，一直执行下去，直到整个数组被遍历完。
        ///
        /// 另外一个思路：
        /// 定义一直指针index，并且初始化为0，它的定义为最左边为零的数字，最开始的时候，不管最左边的值是否为零，接下来开始循环。
        /// 从数组的最左边开始，因为我们的目的是移动零，所以进入循环之后，判断当前数字是否为零，如果是零，就不需要移动，此时因为没有发生过任何数据交换，也就是零也没有移动，所以此时不需要将最左边的零的索引自增。
        /// 如果当前数字不是零，则将最左边为零的索引的值替换为当前的循环的值。因为进行过替换，所以此时需要将index自增，替换之后，此时则需要判断是否将当前循环到的数置为零，判断的方法也很简单，根据最后一行index的自增代码，就是看index和i是否相等，如果相等，则证明i和index是同步自增的，也就是index指向的不为零，不需要置为零，如果不相等，就需要。
        /// </summary>
        /// <param name="nums"></param>
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
    }
}
