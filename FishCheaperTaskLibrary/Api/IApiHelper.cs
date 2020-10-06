using System.Net.Http;

namespace FishCheaperTaskLibrary.Api
{
    public interface IApiHelper
    {
        HttpClient HttpClient { get; }
    }
}