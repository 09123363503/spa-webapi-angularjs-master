using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Extensions;
using System.Net.Http;

namespace HomeCinema.Web.Infrastructure.Core
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public IEntityBaseRepositoryInetger<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBaseInteger, new()
        {
            return request.GetDataRepository<T>();
        }
    }

    public interface IDataRepositoryFactory
    {
        IEntityBaseRepositoryInetger<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBaseInteger, new();
    }
}