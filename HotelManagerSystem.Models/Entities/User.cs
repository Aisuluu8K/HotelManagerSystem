﻿using Microsoft.AspNetCore.Identity;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}