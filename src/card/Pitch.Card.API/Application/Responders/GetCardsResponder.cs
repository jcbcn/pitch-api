﻿using AutoMapper;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using Pitch.Card.API.Application.Requests;
using Pitch.Card.API.Application.Responses;
using Pitch.Card.API.Infrastructure.Services;
using System.Threading.Tasks;

namespace Pitch.Card.API.Application.Responders
{
    public interface IGetCardsResponder
    {
        Task<GetCardsResponse> Response(GetCardsRequest @request);
    }
    public class GetCardsResponder : IGetCardsResponder, IResponder
    {
        private readonly IBus _bus;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GetCardsResponder(IBus bus, IServiceScopeFactory serviceScopeFactory)
        {
            _bus = bus;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Register()
        {
            _bus.RespondAsync<GetCardsRequest, GetCardsResponse>(Response);
        }

        public async Task<GetCardsResponse> Response(GetCardsRequest @request)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var cards = await scope.ServiceProvider.GetRequiredService<ICardService>().GetAsync(@request.Ids);
                return new GetCardsResponse()
                {
                    Cards = cards
                };
            }
        }
    }
}
