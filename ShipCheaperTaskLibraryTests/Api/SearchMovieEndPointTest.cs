using System.Threading.Tasks;
using FishCheaperTaskLibrary.Api;
using FishCheaperTaskLibrary.Models;
using Xunit;

namespace FishCheaperTaskLibraryTests.Api
{
    public class SearchMovieEndPointTest
    {
        [Fact]
        public async Task GetMoviesByTitleTest()
        {
            var movieEndPoint = new SearchMovieEndPoint();
            var actual = await movieEndPoint.GetMoviesByTitle("hitman");
            Assert.NotNull(actual);
        }
    }
}