using HotelManagerSystem.API.Handlers;
using HotelManagerSystem.API.Service;
using HotelManagerSystem.Models.Config;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmailController(EmailService emailService, Config config, IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("send")]
    public async Task SendEmailAsync([FromBody] EmailRequest emailRequest, [FromServices] IMediator mediator)
    {
        await _mediator.Send(new SendEmailCommand(emailRequest));

    }
    [HttpPost("CheckCode")]
    public async Task<Response> CheckCodeAsync(CheckCodeRequest checkCodeRequest)
    {
        return await _mediator.Send(checkCodeRequest);
    }
}