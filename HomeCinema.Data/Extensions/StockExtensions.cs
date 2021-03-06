﻿using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HomeCinema.Data.Extensions
{
    public static class StockExtensions
    {
        public static IEnumerable<Stock> GetAvailableItems(this IEntityBaseRepositoryInetger<Stock> stocksRepository, int movieId)
        {
            IEnumerable<Stock> _availableItems;

            _availableItems = stocksRepository.GetAll().Where(s => s.MovieId == movieId && s.IsAvailable);

            return _availableItems;
        }

        //public static IEnumerable<Stock> GetAllItems(this IEntityBaseRepository<Stock> stocksRepository, int movieId)
        //{
        //    IEnumerable<Stock> _allItems;

        //    _allItems = stocksRepository.GetAll().Where(s => s.MovieId == movieId);

        //    return _allItems;
        //}
    }
}
