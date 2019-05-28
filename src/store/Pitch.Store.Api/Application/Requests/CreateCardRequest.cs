﻿using System;

namespace Pitch.Store.Api.Application.Requests
{
    public class CreateCardRequest
    {
        public CreateCardRequest(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
        public (int? lower, int? upper)? RatingRange { get; set; }
        public string Position { get; set; }
    }
}