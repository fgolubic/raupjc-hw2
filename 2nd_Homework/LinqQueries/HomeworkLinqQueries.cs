using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCorrection;

namespace LinqQueries
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
          
           return  intArray.GroupBy(i => i).OrderBy(g => g.Key)
                .Select(g => $"Broj {g.Key} ponavlja se {g.Count()} puta")
                .ToArray();

        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => !u.Students.Any(s => s.Gender.Equals(Gender.Female))).ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            var avg = universityArray.Average(u => u.Students.Count());

            return universityArray.Where(u => u.Students.Count() < avg).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => !u.Students.Any(s => s.Gender.Equals(Gender.Female)) ||
            !u.Students.Any(s => s.Gender.Equals(Gender.Male))).
                SelectMany(u => u.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).GroupBy(s=>s).Where(g=>g.Count()>1).Select(g=>g.Key).
                ToArray();
        }
    }


}

