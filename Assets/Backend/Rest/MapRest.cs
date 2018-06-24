using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Exceptions;
using Assets.Backend.RestModels;
using Newtonsoft.Json;

namespace Assets.Backend.Rest
{
    class MapRest
    {
        public async Task<List<Map>> GetAllTowns()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var result = await client.GetAsync("/map/all");
                var resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(resultContent);
                        return rootObject.maps;
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }


    }
}