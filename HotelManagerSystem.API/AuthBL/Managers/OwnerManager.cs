using System.Security.Claims;
using System.Threading.Tasks;
using HotelManagerSystem.API.AuthBL.CurrentModels;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.AuthBL.Managers
{
    public class OwnerManager
    {
        private readonly UserManager<User> _userManager;

        public OwnerManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ProfileResponse> GetOwnerProfile(ClaimsPrincipal currentUser)
        {
            var user = await _userManager.GetUserAsync(currentUser);
            if (user == null)
            {
                return new ProfileResponse(404, false, "Owner not found", null);
            }

            var ownerProfile = MapOwnerProfile(user);
            return new ProfileResponse(200, true, "Owner profile retrieved", ownerProfile);
        }

        public async Task<Response> UpdateOwnerProfile(ClaimsPrincipal currentUser, UpdateOwnerProfileRequest request)
        {
            var user = await _userManager.GetUserAsync(currentUser);
            if (user == null)
            {
                return new Response(404, false, "Owner not found");
            }

            UpdateOwnerProperties(user, request);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new Response(200, true, "Owner profile updated");
            }
            else
            {
                string aggregatedErrorMessages = string.Join("\n", result.Errors);
                return new Response(400, false, aggregatedErrorMessages);
            }
        }

        private OwnerProfile MapOwnerProfile(User user)
        {
            return new OwnerProfile()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        private void UpdateOwnerProperties(User user, UpdateOwnerProfileRequest request)
        {
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
        }
    }
}
