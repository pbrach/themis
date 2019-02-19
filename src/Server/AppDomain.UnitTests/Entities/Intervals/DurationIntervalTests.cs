using System;
using System.Collections.Generic;
using AppDomain.Entities;
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
        public void GetTurnNumber(uint? expectedTurn, string testDate)
        {
            var interval = new DurationInterval
            {
                Duration = 7,
                StartDay = DateTime.Parse("2018-12-28")
            };

            var actualTurn = interval.GetTurnNumber(DateTime.Parse(testDate));
            Assert.True(actualTurn == expectedTurn);
        }

        public static IEnumerable<object[]> BetweenTwoDatesData
        {
            get
            {
                yield return new object[] {new List<Assignment>(), "2018-12-26", "2018-12-27"};
                yield return new object[] {new List<Assignment>(), "2018-12-29", "2018-12-28"};
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 0U, FirstActiveDay = DateTime.Parse("2018-12-28"),
                            LastActiveDay = DateTime.Parse("2019-01-03")
                        }
                    },
                    "2018-12-28", "2018-12-28"
                };
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 0U, FirstActiveDay = DateTime.Parse("2018-12-28"),
                            LastActiveDay = DateTime.Parse("2019-01-03")
                        },
                        new Assignment
                        {
                            TurnNumber = 1U, FirstActiveDay = DateTime.Parse("2019-01-04"),
                            LastActiveDay = DateTime.Parse("2019-01-10")
                        },
                        new Assignment
                        {
                            TurnNumber = 2U, FirstActiveDay = DateTime.Parse("2019-01-11"),
                            LastActiveDay = DateTime.Parse("2019-01-17")
                        }
                    },
                    "2018-12-01", "2019-01-14"
                };
                yield return new object[]
                {
                    new List<Assignment>
                    {
                        new Assignment
                        {
                            TurnNumber = 0U, FirstActiveDay = DateTime.Parse("2018-12-28"),
                            LastActiveDay = DateTime.Parse("2019-01-03")
                        },
                        new Assignment
                        {
                            TurnNumber = 1U, FirstActiveDay = DateTime.Parse("2019-01-04"),
                            LastActiveDay = DateTime.Parse("2019-01-10")
                        },
                        new Assignment
                        {
                            TurnNumber = 2U, FirstActiveDay = DateTime.Parse("2019-01-11"),
                            LastActiveDay = DateTime.Parse("2019-01-17")
                        }
                    },
                    "2018-12-01", "2019-01-14"
                };
            }
        }

        [Theory]
        [MemberData(nameof(BetweenTwoDatesData))]
        public void ListAllAssignmentsBetweenTwoDates(List<Assignment> expectedList, string startDate,
            string endDate)
        {
            var interval = new DurationInterval
            {
                Duration = 7,
                StartDay = DateTime.Parse("2018-12-28")
            };

            var assignments = interval.GetAssignmentsBetween(DateTime.Parse(startDate), DateTime.Parse(endDate));
            Assert.Equal(assignments, expectedList);
        }
    }
}