using HotelManagerSystem.API.Managers;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AuthManager _authManager;

    public AuthController(IMediator mediator, AuthManager authManager)
    {
        _mediator = mediator;
        _authManager = authManager;
    }

    [HttpPost("register")]
    public async Task<Response> Register(RegisterUserRequest request)
    {
        var response = await _mediator.Send(request);
        return response;
    }

    [HttpPost("login")]
    public async Task<Response> Login(LoginUserRequest request)
    {
        var response = await _mediator.Send(request);
        return response;
    }
}