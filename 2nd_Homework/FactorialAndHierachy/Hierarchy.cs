using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialAndHierarchy
{
    public class Hierarchy
    {

        public static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result =await  GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            int a = await IKnowWhoKnowsThis(10);
            int b= await IKnowWhoKnowsThis(5);

            return a + b;
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await Factorial.FactorialDigitSum(n);
        }

    }
}
