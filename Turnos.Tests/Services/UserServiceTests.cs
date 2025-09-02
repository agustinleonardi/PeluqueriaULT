using Moq;
using Turnos.Domain.Entities;
using Turnos.Domain.Enums;
using Turnos.Domain.ValueObjects;
using Turnos.Application.Services;
using Turnos.Application.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;
using Turnos.Application.DTOs;
using Turnos.Application.Abstractions.Services;



namespace Turnos.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterUser_Should_Create_User_When_Data_Is_Valid()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var validRequest = new RegisterUserRequest("test@example.com", "password123", "agustin");
            userRepositoryMock.Setup(r => r.GetByEmailAsync(validRequest.Email)).ReturnsAsync((User?)null);
            userRepositoryMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var userService = new UserService(userRepositoryMock.Object, passwordHasherMock.Object);

            // Act
            await userService.CreateUserAsync(validRequest);

            // Assert
            userRepositoryMock.Verify(r => r.AddAsync(It.Is<User>(u =>
                u.Email.Value == validRequest.Email &&
                u.Name == validRequest.Name)), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_UserExists_DeletesUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User(userId, "Test", Email.Create("test@ejemplo.com"), "ola", Role.Client, true, DateTimeOffset.Now, new List<Appointment>());
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            userRepositoryMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);
            var service = new UserService(userRepositoryMock.Object, passwordHasherMock.Object);

            // Act
            await service.DeleteAsync(userId);

            // Assert
            userRepositoryMock.Verify(r => r.DeleteAsync(user), Times.Once);
        }
    }
}
