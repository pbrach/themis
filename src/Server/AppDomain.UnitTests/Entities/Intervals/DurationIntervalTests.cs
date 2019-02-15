using System;
using System.Collections.Generic;
using AppDomain.Entities.Intervals;
using Xunit;

namespace AppDomain.UnitTests.Entities.Intervals
{
    public class DurationIntervalTests
    {
        [Theory]
        [InlineData(null, "2018-12-27")]
        [InlineData(0U, "2019-01-03")]
        [InlineData(1U, "2019-01-04")]
        [InlineData(1U, "2019-01-10")]
        [InlineData(2U, "2019-01-11")]
        [InlineData(3U, "2019-01-18")]
        public void GetAssignedUser(uint? expectedTurn, string testDate)
        {
            var interval = new DurationInterval
            {
                Duration = TimeSpan.FromDays(7),
                StartDay = DateTime.Parse("2018-12-28")
            };

            var actualTurn = interval.GetTurnNumber(DateTime.Parse(testDate));
            Assert.True(actualTurn == expectedTurn);
        }

        [Fact]
        public void ListAllAssignmentsBetweenTwoDates()
        {
            var interval = new DurationInterval
            {
                Duration = TimeSpan.FromDays(7),
                StartDay = DateTime.Parse("2018-12-28")
            };

            // ARGH: theories === attributes do not accept arguments a la: new List<>()... so I take this alternative:
            var emptyList = new List<AssignmentPeriod>();
            var theories = new []
            {
                (emptyList, "2018-12-26", "2018-12-27"),
                (emptyList, "2018-12-29", "2018-12-28"),
                (new List<AssignmentPeriod>
                {
                    new AssignmentPeriod{AssignmentNumber = 0U, FirstActiveDay = DateTime.Parse("2018-12-28"), LastActiveDay = DateTime.Parse("2019-01-03")}
                }, "2018-12-28","2018-12-28"),
                (new List<AssignmentPeriod>
                {
                    new AssignmentPeriod{AssignmentNumber = 0U, FirstActiveDay = DateTime.Parse("2018-12-28"), LastActiveDay = DateTime.Parse("2019-01-03")},
                    new AssignmentPeriod{AssignmentNumber = 1U, FirstActiveDay = DateTime.Parse("2019-01-04"), LastActiveDay = DateTime.Parse("2019-01-10")},
                    new AssignmentPeriod{AssignmentNumber = 2U, FirstActiveDay = DateTime.Parse("2019-01-11"), LastActiveDay = DateTime.Parse("2019-01-17")}
                }, "2018-12-01","2019-01-14"),
            };

            foreach (var (expectedList, startDate, endDate) in theories)
            {
                var assignments = interval.GetAssignmentsBetween(DateTime.Parse(startDate), DateTime.Parse(endDate));
                Assert.Equal(assignments, expectedList);    
            }
            
        }
    }
}