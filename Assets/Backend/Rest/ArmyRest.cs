using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Exceptions;
using Assets.JsonObjects;
using Newtonsoft.Json;

namespace Assets.Backend.Rest
{
    class ArmyRest
    {
        public async Task<bool> TrainArmy(string authenticationToken, ArmyType armyType, int value, int townId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    { "token", authenticationToken },
                    { "armyId", ((int) armyType).ToString() },
                    { "value", value.ToString() },
                    { "townId", townId.ToString() }

                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/army/train", data);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return true;
                    case HttpStatusCode.Unauthorized:
                        throw new AuthenticationException("Token is invalid.");
                    case HttpStatusCode.BadRequest:
                        throw new ArgumentException("Something went wrong on the server.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<bool> MoveArmy(string authenticationToken,
            List<TroopAmount> troopAmount, int targetTownId, int value, int sourceTownId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                MoveArmyJson jsonObject = new MoveArmyJson(troopAmount, targetTownId, sourceTownId, authenticationToken);
                string json = JsonConvert.SerializeObject(jsonObject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/army/move", data);
                System.Threading.Thread.Sleep(2500);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return true;
                    case HttpStatusCode.Unauthorized:
                        throw new AuthenticationException("Token is invalid.");
                    case HttpStatusCode.BadRequest:
                        throw new ArgumentException("Something went wrong on the server.");
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("Could not find one of the towns.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }
    }
}
