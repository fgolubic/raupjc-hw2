using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialAndHierarchy
{
    public class Factorial
    {
        public static async Task<int> FactorialDigitSum(int n)
        {
            int digitSum = await Task.Run(() =>
            {
                int fact = 1;

                for (int i = 1; i <= n; i++)
                {
                    fact *= i;
                }

                int sum = 0;

                while (fact != 0)
                {
                    sum += fact % 10;
                    fact /= 10;

                }


                return sum;

            });
            return digitSum;
        }
    }
}
