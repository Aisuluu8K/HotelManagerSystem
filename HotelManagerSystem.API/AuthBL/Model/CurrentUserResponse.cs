using HotelManagerSystem.Models.Responses;

namespace HotelManagerSystem.API.AuthBL.Model
{
    public class CurrentUserResponse : Response
    {
        public CurrentUserResponse(int statusCode, bool success, string message, UserViewModel user) : base(statusCode, success, message)
        {
            CurrentUser = user;
        }

        public UserViewModel CurrentUser { get; set; }
    }
}
