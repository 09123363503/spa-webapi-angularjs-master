﻿using HomeCinema.Entities;
using HomeCinema.Services.Utilities;
using System.Collections.Generic;

namespace HomeCinema.Services
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(string username, string email, string password, int[] roles);
        User GetUser(int userId);
        List<Role> GetUserRoles(string username);
    }
}
