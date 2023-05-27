namespace HotelManagerSystem.API.Request;

public class UpdateOwnerProfileRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}