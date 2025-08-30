using Microsoft.AspNetCore.Mvc;
using Moq;
using Turnos.API.Controllers;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs;
namespace Turnos.Tests.Controllers;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _controller = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public async Task CreateUser_ReturnsOk_WhenUserIsCreated()
    {
        // Arrange
        var dto = new CreateUserDto("test@mail.com", "123", "Test");
        _userServiceMock.Setup(s => s.CreateUserAsync(dto)).Returns(Task.CompletedTask);
        // Act 
        var result = await _controller.CreateUser(dto);
        // Assert
        _userServiceMock.Verify(s => s.CreateUserAsync(dto), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CreateUser_ReturnsBadRequest_WhenEmailExists()
    {
        // Arrange
        var dto = new CreateUserDto("existe@email.com", "123", "YaExiste");
        _userServiceMock
            .Setup(s => s.CreateUserAsync(dto))
            .ThrowsAsync(new Exception("El email ya existe"));

        // Act
        var result = await _controller.CreateUser(dto);
        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}