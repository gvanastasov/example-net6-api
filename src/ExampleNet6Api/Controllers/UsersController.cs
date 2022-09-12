using Context.Models;
using Context.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace example_net6_api.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserController> _logger;

    public UserController(
        IUserRepository userRepository,
        ILogger<UserController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpGet("")]
    public IEnumerable<User> Get()
    {
        return _userRepository.GetUsers();
    }
}
