using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frank.Brewery.Client.Rest
{
    public interface IRestClient<T>
    {
        Task<T> GetAsync(string url);
        Task<IEnumerable<T>> GetManyAsync(string url);
        Task<T> PostAsync(string url, object body);
        Task<T> PutAsync(string url, object body);
        Task<T> DeleteAsync(string url);
    }
}