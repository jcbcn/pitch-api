﻿using System.Collections.Generic;
using Pitch.Match.API.ApplicationCore.Engine.Events;

namespace Pitch.Match.API.ApplicationCore.Models.Match
{
    public class MatchMinute
    {
        public MatchMinute()
        {
            Modifiers = new List<Modifier>();
            Events = new List<IEvent>();
        }

        public MinuteStats Stats { get; set; }
        public IList<Modifier> Modifiers { get; set; }
        public IList<IEvent> Events { get; set; }
    }
}