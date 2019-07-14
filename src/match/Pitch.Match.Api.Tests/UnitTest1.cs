using System;
using Xunit;
using Pitch.Match.Api.Application.Engine.Action;
using Pitch.Match.Api.Models;
using System.Collections.Generic;
using Pitch.Match.Api.Application.Engine;

namespace Pitch.Match.Api.Tests
{
    public class UnitTest1
    {
        public static Models.Match SetUpMatch()
        {
            var actions = new IAction[] { new Foul(), new Shot() };
            var engine = new MatchEngine(actions);

            var lineup = new Dictionary<string, IEnumerable<Card>>()
                {
                    { "GK", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "GK",
                                Rating = 80,
                                Fitness = 100
                            }
                        }
                    },
                { "DEF", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "LB",
                                Rating = 80,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CB",
                                Rating = 80,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CB",
                                Rating = 80,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "RB",
                                Rating = 80,
                                Fitness = 100
                            }
                        }
                    },
                { "MID", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "LM",
                                Rating = 80,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CM",
                                Rating = 80,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CM",
                                Rating = 80,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "RM",
                                Rating = 80,
                                Fitness = 100
                            }
                        }
                    },
                { "ATT", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ST",
                                Rating = 80,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ST",
                                Rating = 80,
                                Fitness = 100
                            }
                        }
                    }
                };

            var lineup2 = new Dictionary<string, IEnumerable<Card>>()
                {
                    { "GK", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "GK",
                                Rating = 40,
                                Fitness = 100
                            }
                        }
                    },
                { "DEF", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "LB",
                                Rating = 40,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CB",
                                Rating = 40,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CB",
                                Rating = 40,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "RB",
                                Rating = 40,
                                Fitness = 100
                            }
                        }
                    },
                { "MID", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "LM",
                                Rating = 40,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CM",
                                Rating = 40,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "CM",
                                Rating = 40,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "RM",
                                Rating = 40,
                                Fitness = 100
                            }
                        }
                    },
                { "ATT", new List<Card>()
                        {
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ST",
                                Rating = 40,
                                Fitness = 100
                            },
                            new Card()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ST",
                                Rating = 40,
                                Fitness = 100
                            }
                        }
                    }
                };

            var squad1 = new Squad()
            {
                Id = Guid.NewGuid(),
                Lineup = lineup,
                Subs = new Card[] {
                    new Card()
                    {
                        Id = Guid.NewGuid(),
                        Name = "ST",
                        Rating = 40,
                        Fitness = 100
                    }
                },
                Name = "Good FC"
            };

            var squad2 = new Squad()
            {
                Id = Guid.NewGuid(),
                Lineup = lineup2,
                Subs = new Card[] {
                    new Card()
                    {
                        Id = Guid.NewGuid(),
                        Name = "ST",
                        Rating = 40,
                        Fitness = 100
                    }
                },
                Name = "Shitty FC"
            };

            var user1 = Guid.NewGuid();
            var user2 = Guid.NewGuid();

            var match = new Models.Match()
            {
                Id = Guid.NewGuid(),
                KickOff = DateTime.Now,
                HomeTeam = new TeamDetails()
                {
                    UserId = user1,
                    Squad = squad1,
                },
                AwayTeam = new TeamDetails()
                {
                    UserId = user2,
                    Squad = squad2
                }
            };
            var result = engine.SimulateReentrant(match);
            return result;
        }

        [Fact]
        public void Test1()
        {
            var result = SetUpMatch();
            var matchResult = new MatchResult(result);
        }
    }
}
