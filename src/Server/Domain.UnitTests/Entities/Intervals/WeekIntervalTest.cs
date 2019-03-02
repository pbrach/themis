using System;
using System.Collections.Generic;
using AppDomain.Entities;
using AppDomain.Entities.Intervals;
using Xunit;

namespace AppDomain.UnitTests.Entities.Intervals
{
    public class WeekIntervalTest
    {
        [Theory]
        [InlineData(null, "2019-02-03")]
        [InlineData(0U, "2019-02-04")]
        [InlineData(0U, "2019-02-11")]
        [InlineData(0U, "2019-02-10")]
        [InlineData(0U, "2019-02-17")]
        [InlineData(1U, "2019-02-18")]
        [InlineData(1U, "2019-03-03")]
        [InlineData(2U, "2019-03-04")]
        public void GetTurnNumber(uint? expectedTurn, string date)
        {
            var interval = new WeekInterval
            {
                StartDay = DateTime.Parse("2019-02-04"),
                Duration = 2,
                StartOfWeek = DayOfWeek.Monday
            };

            var turnNumber = interval.GetTurnNumber(DateTime.Parse(date));
            Assert.Equal(expectedTurn, turnNumber);
        }


        public static IEnumerable<object[]> BetweenTwoDatesData1
        {
            get
            {
                yield return new object[] {new List<Assignment>(), "2018-12-26", "2018-12-27"};
                yield return new object[] {new List<Assignment>(), "2018-12-29", "2019-01-28"};
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 0U, FirstActiveDay = DateTime.Parse("2019-01-28"),
                            LastActiveDay = DateTime.Parse("2019-02-17")
                        }
                    },
                    "2019-01-29", "2019-01-29"
                };
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 2U, FirstActiveDay = DateTime.Parse("2019-03-11"),
                            LastActiveDay = DateTime.Parse("2019-03-31")
                        }
                    },
                    "2019-03-27", "2019-04-10"
                };
            }
        }

        [Theory]
        [MemberData(nameof(BetweenTwoDatesData1))]
        public void ListAllAssignmentsBetweenTwoDates(List<Assignment> expectedList, string startDate,
            string endDate)
        {
            var interval = new WeekInterval
            {
                Duration = 3,
                StartDay = DateTime.Parse("2019-01-28"),
                StartOfWeek = DayOfWeek.Monday
            };

            var assignments = interval.GetAssignmentsBetween(DateTime.Parse(startDate), DateTime.Parse(endDate));
            Assert.Equal(assignments, expectedList);
        }
    }
}