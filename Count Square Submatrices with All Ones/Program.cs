using System;
using System.Linq;

namespace Count_Square_Submatrices_with_All_Ones
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      /*
       Input: matrix =
      [
        [0,1,1,1],
        [1,1,1,1],
        [0,1,1,1]
      ]
      Output: 15
      Explanation: 
      There are 10 squares of side 1.
      There are 4 squares of side 2.
      There is  1 square of side 3.
      Total number of squares = 10 + 4 + 1 = 15.
       */
    }
  }

  public class Solution
  {
    public int CountSquares(int[][] matrix)
    {
      int count = 0;
      int row = matrix.Length;
      int[][] dp = new int[row][];

      for (int i = row - 1; i >= 0; i--)
      {
        dp[i] = new int[matrix[i].Length];
        for (int j = matrix[i].Length - 1; j >= 0; j--)
        {
          if (i == row - 1 || j == matrix[i].Length - 1)
          {
            dp[i][j] = matrix[i][j];
            count += dp[i][j];
            continue;
          }

          if (matrix[i][j] == 1)
          {
            int right = dp[i][j + 1];
            int down = dp[i + 1][j];
            int diagonal = dp[i + 1][j + 1];
            dp[i][j] = new int[] { right, down, diagonal }.Min() + 1;
            count += dp[i][j];
          }
        }
      }

      return count;
    }
  }
}
