using hotels.Application.Contracts.ServicesInterfaces;
using hotels.Application.Events.User.Commands;
using hotels.Application.Events.User.Queries;
using hotels.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Presentation.Http.Controllers;

[ApiController]
[Route("api/v1/users/")]

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(uint userId)
    {
        try
        {
            var reservationModel = await _mediator.Send(new GetUserInfoQuery(userId));
            return Ok(reservationModel);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            var command = new CreateUserCommand(
                createUserDto.Login,
                createUserDto.Password,
                createUserDto.FirstName,
                createUserDto.LastName,
                createUserDto.Phone,
                createUserDto.Email,
                createUserDto.Birthday,
                createUserDto.Passport);
            var userId = await _mediator.Send(command);
            return Ok($"New user id is {userId}");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(uint userId)
    {
        try
        {
            await _mediator.Send(new DeleteUserCommand(userId));
            return Ok("User was successfully deleted");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
    {
        try
        {
            var command = new UpdateUserCommand(
                updateUserDto.UserId,
                updateUserDto.Login,
                updateUserDto.Password,
                updateUserDto.FirstName,
                updateUserDto.LastName,
                updateUserDto.Email,
                updateUserDto.Phone,
                updateUserDto.Birthday,
                updateUserDto.Passport);
            await _mediator.Send(command);
            return Ok($"User updated.");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
}