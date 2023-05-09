using HotelManagerSystem.API.AuthBL.Model;
using HotelManagerSystem.API.Repositories;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace HotelManagerSystem.API.Handlers
{
    public class CheckCodeHandler : IRequestHandler<CheckCodeRequest, Response>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;

        public CheckCodeHandler(IMemoryCache memoryCache,
            IUserRepository userRepository,
            SignInManager<User> signInManager)
        {
            _memoryCache = memoryCache;
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task<Response> Handle(CheckCodeRequest request, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(request.Email, out _) )
            {
                if (!await _userRepository.UpdateUserEmailConfirmedFlag(request.Email))
                    return new Response(404, false, $"User with {request.Email} email was't found");

                var user = await _userRepository.GetUserByEmailAsync(request.Email);
                await _signInManager.SignInAsync(user, isPersistent: false);

                return new Response(200, true, "Code confirmed successfully");
            }
            else
            {
                return new Response(400, false, "Time of code validity expired, please reregister to get a new code");
            }
        }
    }
}
