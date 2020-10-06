using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FishCheaperTaskLibrary.Helpers;
using FishCheaperTaskLibrary.Models;

namespace FishCheaperTaskLibrary.Api
{
    public class SearchMovieEndPoint
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<object> GetMoviesByTitle(string title)
        {
            var url = OmdbUriBuilder.GetUri(new Dictionary<string, string> { { "t", title } });
            using (var responseMessage = await _client.GetAsync(url))
            {
                if (!responseMessage.IsSuccessStatusCode) return null;
                var output  = await responseMessage.Content.ReadFromJsonAsync<MovieInfo>();
                return output;
            }
        }
    }
}