using AutoMapper;
using Context.Models;
using Context.Repositories.Interfaces;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace example_net6_api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public readonly IMapper _mapper;
    private readonly ILogger<UsersController> _logger;

    public UsersController(
        IUserRepository userRepository,
        IMapper mapper,
        ILogger<UsersController> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("")]
    public IEnumerable<UserResponse> Get()
    {
        var users = _userRepository.GetUsers();
        return _mapper.Map<IEnumerable<UserResponse>>(users);
    }
}
