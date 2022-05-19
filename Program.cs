
/*To find the maximum sum of sub array from an array
arr = [-5, 4, 6, -3, 4, -1]
find a sub array from above array which has maximum sum
in above example; sum of [4, 6, -3, 4] = 11 {has the maximum sum}

-----------------------
input           output        
[1]             1
[1,2]           2
[1,2,3]         6
[1,-2]          1
[1,-2,1]        1
[1,-2,2]        2
[5,-4,-2,6,-1]  6

Base rule: if sum of any part is -ve then don't include that part into sub array

Brute Force solution:
step 1: to find out ALL sub arrays.
step 2: sum all of them individually.
step 3: find the max 

*/

using System.Diagnostics;

int GetMaxSubArraySum_BruteForce(List<int> arr)
{
    int max_sum = int.MinValue;
    for (int i = 0; i < arr.Count; i++)
    {
        int curr_sum = 0;
        for (int j = i; j < arr.Count; j++)
        {
            curr_sum = curr_sum + arr[j];
            if (curr_sum > max_sum)
            {
                max_sum = curr_sum;
            }
        }
    }
    return max_sum;
}

int GetMaxSubArraySum_Kadanes(List<int> arr)
{
    int max_sum = 0;
    int curr_sum = 0;
    for (int i = 0; i < arr.Count; i++)
    {
        curr_sum = curr_sum + arr[i];
        if (curr_sum > max_sum)
        {
            max_sum = curr_sum;
        }
        if (curr_sum < 0)
            curr_sum = 0;
    }
    return max_sum;
}

var arr = new List<int>();
var rand = new Random();
int num = 0;
for (int i = 1; i < 400000; i++)
{
    num = rand.Next(10);
    arr.Add(num);
}

Stopwatch stopWatch = new Stopwatch();
Console.WriteLine("Kadane's Algo:");
stopWatch.Start();
Console.WriteLine($"Result: {GetMaxSubArraySum_Kadanes(arr)} ");

stopWatch.Stop();
TimeSpan ts = stopWatch.Elapsed;
Console.WriteLine($"Time spent: {ts}");


Console.WriteLine();
stopWatch.Reset();
Console.WriteLine("Brute Force approach:");
stopWatch.Start();
Console.WriteLine($"Result: {GetMaxSubArraySum_BruteForce(arr)} ");
stopWatch.Stop();
ts = stopWatch.Elapsed;
Console.WriteLine($"Time spent: {ts}");
