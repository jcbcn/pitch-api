﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pitch.Squad.Api.Services;

namespace Pitch.Squad.Api.Controllers
{
    [Authorize]
    [Route("")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly ISquadService _squadService;
        public SquadController(ISquadService activeSquadService)
        {
            _squadService = activeSquadService;
        }

        // GET /
        [HttpGet]
        public async Task<Models.Squad> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //TODO move to currentUserContext
            return await _squadService.GetOrCreateAsync(userId);
        }
    }
}
