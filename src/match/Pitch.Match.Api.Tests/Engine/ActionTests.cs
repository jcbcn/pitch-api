﻿using System;
using Pitch.Match.API.ApplicationCore.Engine.Events;
using Pitch.Match.API.ApplicationCore.Engine.Providers;
using Pitch.Match.API.ApplicationCore.Models;
using Xunit;
using Foul = Pitch.Match.API.ApplicationCore.Engine.Actions.Foul;

namespace Pitch.Match.API.Tests.Engine
{
    public class ActionTests
    {
        public class TestRandomnessProvider : IRandomnessProvider
        {
            private readonly int value;

            public TestRandomnessProvider(int value)
            {
                this.value = value;
            }

            public int Next(int minValue, int maxValue)
            {
                return value;
            }
        }

        [Fact]
        public void FoulAction_CanSpawn_FoulEvent()
        {
            //Arrange
            var randomnessProvider = new TestRandomnessProvider(6);
            var foul = new Foul(randomnessProvider);
            var card = new Card {Id = Guid.NewGuid()};

            //Act
            var @event = foul.SpawnEvent(card, new Guid(), 0, new ApplicationCore.Models.Match());

            //Assert
            Assert.Equal(typeof(ApplicationCore.Engine.Events.Foul), @event.GetType());
        }

        [Fact]
        public void FoulAction_CanSpawn_RedCardEvent()
        {
            //Arrange
            var randomnessProvider = new TestRandomnessProvider(1);
            var foul = new Foul(randomnessProvider);
            var card = new Card {Id = Guid.NewGuid()};

            //Act
            var @event = foul.SpawnEvent(card, new Guid(), 0, new ApplicationCore.Models.Match());

            //Assert
            Assert.Equal(typeof(RedCard), @event.GetType());
        }

        [Fact]
        public void FoulAction_CanSpawn_YellowCardEvent()
        {
            //Arrange
            var randomnessProvider = new TestRandomnessProvider(3);
            var foul = new Foul(randomnessProvider);
            var card = new Card {Id = Guid.NewGuid()};

            //Act
            var @event = foul.SpawnEvent(card, new Guid(), 0, new ApplicationCore.Models.Match());

            //Assert
            Assert.Equal(typeof(YellowCard), @event.GetType());
        }

        [Fact]
        public void FoulAction_OnAYellowCard_WithASecondYellow_ShouldSpawnARedCardEvent()
        {
            //Arrange
            var randomnessProvider = new TestRandomnessProvider(3);
            var foul = new Foul(randomnessProvider);
            var cardId = Guid.NewGuid();
            var card = new Card {Id = cardId};
            var match = new ApplicationCore.Models.Match();
            match.Events.Add(new YellowCard(5, cardId, new Guid()));

            //Act
            var @event = foul.SpawnEvent(card, new Guid(), 10, match);

            //Assert
            Assert.Equal(typeof(RedCard), @event.GetType());
        }

        [Fact]
        public void FoulAction_WithInvalidRandomNumber_ShouldSpawnNullEvent()
        {
            //Arrange
            var randomnessProvider = new TestRandomnessProvider(-1);
            var foul = new Foul(randomnessProvider);
            var card = new Card {Id = Guid.NewGuid()};

            //Act
            var @event = foul.SpawnEvent(card, new Guid(), 0, new ApplicationCore.Models.Match());

            //Assert
            Assert.Null(@event);
        }
    }
}