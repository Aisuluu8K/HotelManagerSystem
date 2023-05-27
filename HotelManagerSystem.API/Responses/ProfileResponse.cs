using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.API.Responses;

public class ProfileResponse : Response
{
    public OwnerProfile Profile { get; set; }

    public ProfileResponse(int statusCode, bool success, string message, OwnerProfile profile)
        : base(statusCode, success, message)
    {
        Profile = profile;
    }
}