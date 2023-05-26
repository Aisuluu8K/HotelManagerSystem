﻿using DorgramApi.WebAPI.AuthBL.Models;
using HotelManagerSystem.API.AuthBL.Models;

namespace HotelManagerSystem.API.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> UpdateUserEmailConfirmedFlag(string email);
        public Task<User> GetUserByEmailAsync(string email);
        public Task RemoveUserByEmail(string email);
        public Task<bool> UpdateUserEmailAsync(string oldEmail, string newEmail);
    }
}
