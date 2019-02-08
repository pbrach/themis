using System;
using System.Globalization;


// perhaps use:
// https://www.nuget.org/packages/Dates.Recurring/
// or an alternative for also iCal compatibility:
// https://github.com/rianjs/ical.net

// NOTE: missing is, which interval we are currently in. E.g: 
//       if the interval set to two weeks, we only know that in the
//       current week person x has his turn, but we do not know 
//       if it is only this week left or if also next week is okay.
// IDEA: just use: 
// var turnStart = intervalStartDate + numIntervals * intervalLength;
// but intervalStart != startDate, because startDate might not be first day of week...
// 
public class Program
{
  public static void Main()
  {
    var users = new string[]{"Bob", "Cal", "Edward", "Hugo"}; // assume the first person (bob) starts
    var start = new DateTime(2017, 12, 1);
    var current = new DateTime(2018, 1, 5);
    

    current = new DateTime(2017, 12, 5);
    var diff = GetMonthDifference(start, current);
    Console.WriteLine(current.ToShortDateString() + " it is " +  users[diff % users.Length] + "'s turn");

    current = new DateTime(2018, 1, 5);
    diff = GetMonthDifference(start, current);
    Console.WriteLine(current.ToShortDateString() + " it is " +  users[diff % users.Length] + "'s turn");

    current = new DateTime(2018, 2, 5);
    diff = GetMonthDifference(start, current);
    Console.WriteLine(current.ToShortDateString() + " it is " +  users[diff % users.Length] + "'s turn");

    current = new DateTime(2018, 3, 5);
    diff = GetMonthDifference(start, current);
    Console.WriteLine(current.ToShortDateString() + " it is " +  users[diff % users.Length] + "'s turn");

    
  }

  public static int GetMonthDifference(DateTime startDate, DateTime endDate)
  {
    int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
    return Math.Abs(monthsApart);
  }

  public static int WeekDifference(DateTime startDate, DateTime endDate)
  {
    // even better implementation here:
    // https://stackoverflow.com/questions/4604199/how-to-calculate-number-of-weeks-given-2-dates

    Calendar myCal = CultureInfo.InvariantCulture.Calendar;
    int weeks = (int)(endDate - startDate).TotalDays / 7;
    return weeks;
  }
}
