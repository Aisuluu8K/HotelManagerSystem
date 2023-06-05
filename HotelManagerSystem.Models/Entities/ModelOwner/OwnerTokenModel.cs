namespace HotelManagerSystem.Models.Entities.ModelOwner;

public class OwnerTokenModel
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiresIn { get; set; }
    public string Role { get; set; }
}