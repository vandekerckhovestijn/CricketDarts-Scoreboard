﻿using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Services.Interfaces;
using Pin.CricketDarts.Shared;
using System.Net.Http;

namespace Pin.CricketDarts.Server.Services.Api
{
    public class GameService : IGameService
    {
        private string baseUrl = "https://localhost:7117/api/Games";
        private readonly HttpClient _httpClient;

        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreateGame(Game game)
        {
            var dto = new GameRequestDto
            {
                Id = game.Id,
                IsActive = game.IsActive
            };
            return _httpClient.PostAsJsonAsync<GameRequestDto>(baseUrl, dto);
        }

        public async Task<List<Game>> GetGames()
        {
            var games = await _httpClient.GetFromJsonAsync<GameResponseDto[]>($"{baseUrl}");

            return games.Select(p => new Game
            {
                Id = p.Id,
                IsActive = p.IsActive,
                Players = p.Players.Select(c => new Player
                {
                    Id = c.Id,
                    Name = c.Name,
                    HasTurn= c.HasTurn,
                }).ToList(),
                ScoreBoardEntries = p.ScoreBoardEntries.Select(s => new ScoreBoardEntry
                {
                    GameId = s.Id,
                    Id = s.Id,
                    PlayerId = s.PlayerId,
                    Status = s.Status,
                    Target = s.Target
                }).ToList()
            }).ToList();
        }

        public async Task UpdateGame(Game game)
        {
            var dto = new GameRequestDto
            {
                Id = game.Id,
                IsActive = game.IsActive,
                ScoreBoardEntries = game.ScoreBoardEntries.Select(s => new ScoreBoardEntryRequestDto
                {
                    GameId = s.Id,
                    PlayerId = s.PlayerId,
                    Status = s.Status,
                    Target = s.Target
                }).ToList(),
                WinnerId = game.WinnerId,
            };

            await _httpClient.PutAsJsonAsync<GameRequestDto>($"{baseUrl}", dto);
        }
    }
}
