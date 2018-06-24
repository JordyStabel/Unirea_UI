using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Exceptions;
using Newtonsoft.Json;

namespace Assets.Backend.Rest
{
    class BuildingRest
    {
        public async Task<bool> LevelUpBuilding(string authenticationToken, int townId,  BuildingType buildingType)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    { "token", authenticationToken },
                    { "townId", townId.ToString() },
                    { "buildingId", ((int)buildingType).ToString() }

                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/building/levelup", data);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return true;
                    case HttpStatusCode.Unauthorized:
                        throw new AuthenticationException("Accesstoken is invalid.");
                    case HttpStatusCode.BadRequest:
                        throw new ArgumentException("Something went wrong on the server.");
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("Could not find town.");
                    case HttpStatusCode.Conflict:
                        throw new NotEnoughResourcesException();
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }
    }
}
