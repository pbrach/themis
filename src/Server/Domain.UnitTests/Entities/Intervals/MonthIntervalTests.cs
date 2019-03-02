using System;
using System.Collections.Generic;
using AppDomain.Entities;
using AppDomain.Entities.Intervals;
using Xunit;

namespace AppDomain.UnitTests.Entities.Intervals
{
    public class MonthIntervalTests
    {
        [Theory]
        [InlineData(null, "2018-12-31")]
        [InlineData(0U, "2019-01-04")]
        [InlineData(0U, "2019-02-15")]
        [InlineData(0U, "2019-02-28")]
        [InlineData(1U, "2019-03-01")]
        [InlineData(1U, "2019-03-17")]
        [InlineData(1U, "2019-04-30")]
        [InlineData(2U, "2019-06-03")]
        [InlineData(3U, "2019-08-04")]
        [InlineData(4U, "2019-09-04")]
        public void GetTurnNumber_Duration2(uint? expectedTurn, string date)
        {
            var interval = new MonthInterval
            {
                StartDay = DateTime.Parse("2019-01-15"),
                Duration = 2
            };

            var turnNumber = interval.GetTurnNumber(DateTime.Parse(date));
            Assert.Equal(expectedTurn, turnNumber);
        }
        
        
        [Theory]
        [InlineData(null, "2018-12-31")]
        [InlineData(0U, "2019-01-04")]
        [InlineData(1U, "2019-02-15")]
        [InlineData(1U, "2019-02-28")]
        [InlineData(2U, "2019-03-01")]
        [InlineData(2U, "2019-03-17")]
        [InlineData(3U, "2019-04-30")]
        [InlineData(5U, "2019-06-03")]
        [InlineData(7U, "2019-08-04")]
        [InlineData(8U, "2019-09-04")]
        public void GetTurnNumber_Duration1(uint? expectedTurn, string date)
        {
            var interval = new MonthInterval
            {
                StartDay = DateTime.Parse("2019-01-31"),
                Duration = 1
            };

            var turnNumber = interval.GetTurnNumber(DateTime.Parse(date));
            Assert.Equal(expectedTurn, turnNumber);
        }
        
        
        
        
        public static IEnumerable<object[]> BetweenTwoDatesData1
        {
            get
            {
                yield return new object[] {new List<Assignment>(), "2019-12-26", "2019-12-20"};
                yield return new object[] {new List<Assignment>(), "2018-12-26", "2018-12-27"};
                yield return new object[] {new List<Assignment>(), "2018-12-29", "2019-01-28"};
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 0U, FirstActiveDay = DateTime.Parse("2019-01-01"),
                            LastActiveDay = DateTime.Parse("2019-01-31")
                        },
                        new Assignment
                        {
                            TurnNumber = 1U, FirstActiveDay = DateTime.Parse("2019-02-01"),
                            LastActiveDay = DateTime.Parse("2019-02-28")
                        }
                    },
                    "2019-01-28", "2019-02-28"
                };
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 0U, FirstActiveDay = DateTime.Parse("2019-01-01"),
                            LastActiveDay = DateTime.Parse("2019-01-31")
                        }
                    },
                    "2018-12-27", "2019-01-31"
                };
            }
        }
        
        
        [Theory]
        [MemberData(nameof(BetweenTwoDatesData1))]
        public void ListAllAssignmentsBetweenTwoDates(List<Assignment> expectedList, string startDate,
            string endDate)
        {
            var interval = new MonthInterval
            {
                Duration = 1,
                StartDay = DateTime.Parse("2019-01-28")
            };

            var assignments = interval.GetAssignmentsBetween(DateTime.Parse(startDate), DateTime.Parse(endDate));
            Assert.Equal(assignments, expectedList);
        }
        
        
        
        public static IEnumerable<object[]> BetweenTwoDatesData2
        {
            get
            {
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 0U, FirstActiveDay = DateTime.Parse("2019-01-01"),
                            LastActiveDay = DateTime.Parse("2019-03-31")
                        },
                        new Assignment
                        {
                            TurnNumber = 1U, FirstActiveDay = DateTime.Parse("2019-04-01"),
                            LastActiveDay = DateTime.Parse("2019-06-30")
                        },
                        new Assignment
                        {
                            TurnNumber = 2U, FirstActiveDay = DateTime.Parse("2019-07-01"),
                            LastActiveDay = DateTime.Parse("2019-09-30")
                        }
                    },
                    "2018-11-28", "2019-09-28"
                };
            }
        }
        
        [Theory]
        [MemberData(nameof(BetweenTwoDatesData2))]
        public void ListAllAssignmentsBetweenTwoDates2(List<Assignment> expectedList, string startDate,
            string endDate)
        {
            var interval = new MonthInterval
            {
                Duration = 3,
                StartDay = DateTime.Parse("2019-01-28")
            };

            var assignments = interval.GetAssignmentsBetween(DateTime.Parse(startDate), DateTime.Parse(endDate));
            Assert.Equal(assignments, expectedList);
        }
    }
}