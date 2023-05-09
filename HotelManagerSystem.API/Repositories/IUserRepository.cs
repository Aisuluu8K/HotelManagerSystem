using HotelManagerSystem.API.AuthBL.Model;

namespace HotelManagerSystem.API.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> UpdateUserEmailConfirmedFlag(string email);
        public Task<User> GetUserByEmailAsync(string email);
        public Task RemoveUserByEmail(string email);
    }
}
