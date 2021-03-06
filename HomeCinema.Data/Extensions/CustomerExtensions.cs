﻿using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using System.Linq;

namespace HomeCinema.Data.Extensions
{
    public static class CustomerExtensions
    {
        public static bool UserExists(this IEntityBaseRepositoryInetger<Customer> customersRepository, string email, string identityCard)
        {
            bool _userExists = false;

            _userExists = customersRepository.GetAll()
                .Any(c => c.Email.ToLower() == email ||
                c.IdentityCard.ToLower() == identityCard);

            return _userExists;
        }

        public static string GetCustomerFullName(this IEntityBaseRepositoryInetger<Customer> customersRepository, int customerId)
        {
            string _customerName = string.Empty;

            var _customer = customersRepository.GetSingle(customerId);

            _customerName = _customer.FirstName + " " + _customer.LastName;

            return _customerName;
        }
    }
}
