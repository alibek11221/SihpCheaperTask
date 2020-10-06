using System.Threading.Tasks;
using ShipCheaperTaskLibrary.Api;
using Xunit;

namespace ShipCheaperTaskLibraryTests.Api
{
    public class SearchMovieEndPointTest
    {
        [Fact]
        public async Task GetMoviesByTitleTest()
        {
            var movieEndPoint = new SearchMovieEndPoint();
            var actual = await movieEndPoint.GetMoviesByTitle("Hitman");
            Assert.NotNull(actual.Genre);
        }
    }
}