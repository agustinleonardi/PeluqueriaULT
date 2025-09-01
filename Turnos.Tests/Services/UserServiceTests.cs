using Xunit;
using Moq;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Application.DTOs;
using Turnos.Domain.Entities;
using Turnos.Application.Services;
using Microsoft.AspNetCore.Identity;
using Turnos.Application.Abstractions.Services;
using System.Threading.Tasks;
using AutoMapper;
// ...otros using necesarios...

namespace Turnos.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterUser_Should_Create_User_When_Data_Is_Valid()
        {
            // Arrange
            // TODO: configurar mocks y datos de prueba
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var mapperMock = new Mock<IMapper>();
            var validRequest = new RegisterUserRequest("test@example.com", "password123", "agustin");
            userRepositoryMock.Setup(r => r.GetByEmailAsync(validRequest.Email)).ReturnsAsync((User?)null);
            userRepositoryMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var userService = new UserService(userRepositoryMock.Object, passwordHasherMock.Object);

            // Act
            // TODO: llamar al método a testear
            await userService.CreateUserAsync(validRequest);

            // Assert
            // TODO: verificar el resultado esperado
            userRepositoryMock.Verify(r => r.AddAsync(It.Is<User>(u =>
            u.Email.Value == validRequest.Email &&
            u.Name == validRequest.Name)), Times.Once);
        }
    }
}
