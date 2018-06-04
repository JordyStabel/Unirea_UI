﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Exceptions;
using Assets.Backend.Models;
using Newtonsoft.Json;

namespace Assets.Backend.Rest
{
    class TownRest
    {
        public async Task<Town> GetTown(string authenticationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken}

                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/town/get", data);
                var resultContent = await result.Content.ReadAsStringAsync();
                var town = JsonConvert.DeserializeObject<Town>(resultContent);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return town;
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("The player's login session has expired.");
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("The town of the specified player was not found.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<Town> CreateTown(string authenticationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken}

                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/town/create", data);
                var resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var town = JsonConvert.DeserializeObject<Town>(resultContent);
                        return town;
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("The player's login session has expired.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<List<Town>> GetAllTownsFromPlayer(string authenticationToken, int playerId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken},
                    {"playerId", playerId.ToString()}
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/town/all", data);
                var resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        List<Town> towns = JsonConvert.DeserializeObject<List<Town>>(resultContent);
                        return towns;
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("Could not find towns of specified player.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }
    }
}