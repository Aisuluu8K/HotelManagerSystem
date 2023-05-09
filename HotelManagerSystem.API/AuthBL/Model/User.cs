using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.AuthBL.Model;

public class User : IdentityUser
{
    public string FullName { get; set; }
    public bool IsEmailConfirmed { get; set; }
}