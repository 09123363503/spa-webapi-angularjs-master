﻿using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Services;
using System.Net.Http;
using System.Web.Http.Dependencies;

namespace HomeCinema.Web.Infrastructure.Extensions
{
    public static class RequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        internal static IEntityBaseRepositoryInetger<T> GetDataRepository<T>(this HttpRequestMessage request) where T : class, IEntityBaseInteger, new()
        {
            return request.GetService<IEntityBaseRepositoryInetger<T>>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}