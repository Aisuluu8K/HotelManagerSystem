using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using HotelManagerSystem.Models.Responses;
using MediatR;

namespace HotelManagerSystem.Models.Request
{
    public class LoginUserRequest : IRequest<Response>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
