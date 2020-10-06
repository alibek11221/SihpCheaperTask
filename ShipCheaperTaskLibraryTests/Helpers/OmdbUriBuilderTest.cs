using System;
using System.Collections.Generic;
using FishCheaperTaskLibrary.Helpers;
using Xunit;

namespace FishCheaperTaskLibraryTests.Helpers
{
    public class OmdbUriBuilderTest
    {
        [Fact]
        public void GetUriTest()
        {
            var actual = OmdbUriBuilder.GetUri(new Dictionary<string, string> {{"t", "hitman"}});
            var expected = new Uri("http://www.omdbapi.com/?apikey=b1b769fe&type=movie&r=json&t=hitman");
            Assert.Equal(expected, actual);
        }
    }
}