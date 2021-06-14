using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public int differenceBetweenTwoDates { get; set; }

        public void GetDifferenceBetweenTwoDates(string firstDate, string secondDate)
        {
            int[] firstDateElements = firstDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int year1 = firstDateElements[0];
            int months1 = firstDateElements[1];
            int days1 = firstDateElements[2];

            int monthAndDaySum1 = 0;

            if (year1 % 4 == 0)
            {
                monthAndDaySum1 -= 1;
            }

            monthAndDaySum1 += days1;

            for (int i = 1; i < months1; i++)
            {
                monthAndDaySum1 += DateTime.DaysInMonth(year1, i);
            }
         
            int totalDaysFirstDate = (year1 * 365) + (year1 / 4) + monthAndDaySum1;

            int[] secondDateElements = secondDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int year2 = secondDateElements[0];
            int months2 = secondDateElements[1];
            int days2 = secondDateElements[2];

            int monthAndDaySum2 = 0;

            if (year2 % 4 == 0)
            {
                monthAndDaySum2 -= 1;
            }

            monthAndDaySum2 += days2;


            for (int i = 1; i < months2; i++)
            {
                monthAndDaySum2 += DateTime.DaysInMonth(year2, i);
            }

            int totalDaysSecondDate = (year2 * 365) + (year2 / 4) + monthAndDaySum2;


            differenceBetweenTwoDates = Math.Abs(totalDaysFirstDate - totalDaysSecondDate);
        }
    }
}
