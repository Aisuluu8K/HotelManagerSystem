﻿using System.Security.Claims;
using HotelManagerSystem.API.AuthBL.Model;
using HotelManagerSystem.Common;
using HotelManagerSystem.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.Managers
{
    public class AuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthManager(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<CurrentUserResponse> GetCurrentUser(ClaimsPrincipal currentUserClaims)
        {
            var user = await _userManager.GetUserAsync(currentUserClaims);

            return GetCurrentUserResponse(user);
        }

        public CurrentUserResponse GetCurrentUserResponse(User user)
        {
            if (user == null)
            {
                return new CurrentUserResponse(404, false, "Current user not found", null);
            }
            var userVm = MapUser(user);

            return new CurrentUserResponse(200, true, "User recieved", userVm);
        }

        private UserViewModel MapUser(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                EmailConfirmed = user.IsEmailConfirmed,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
