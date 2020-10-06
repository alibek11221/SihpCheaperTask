using System;
using System.Collections.Generic;
using System.Web;

namespace ShipCheaperTaskLibrary.Helpers
{
    public static class OmdbUriBuilder
    {
        private const string BaseUrl = "http://www.omdbapi.com/";

        public static Uri GetUri(Dictionary<string, string> query)
        {
            var output = new UriBuilder(BaseUrl);
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["apikey"] = "b1b769fe";
            queryString["type"] = "movie";
            queryString["r"] = "json";

            foreach (var key in query.Keys)
            {
                query.TryGetValue(key, out var val);
                queryString[key] = val;
            }

            output.Query = queryString.ToString();
            return output.Uri;
        }
    }
}