using System.Threading.Tasks;

namespace AlbumApi.Helpers
{
    public interface IHttpClientHelper
    {
        Task<T> GetAndDeserializeAsync<T>(string requestUri);
    }
}