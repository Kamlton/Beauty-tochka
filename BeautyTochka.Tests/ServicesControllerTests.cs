using BeautyTochka.API.Controllers;
using BeautyTochka.API.DTOs;
using BeautyTochka.API.Models;
using BeautyTochka.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BeautyTochka.Tests;

public class ServicesControllerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IRepository<Service>> _serviceRepoMock;
    private readonly ServicesController _controller;

    public ServicesControllerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _serviceRepoMock = new Mock<IRepository<Service>>();
        _unitOfWorkMock.Setup(u => u.Services).Returns(_serviceRepoMock.Object);
        _controller = new ServicesController(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfServices()
    {
        // Arrange
        var services = new List<Service>
        {
            new Service { Id = 1, Name = "Маникюр", Category = "Маникюр", Price = "1000₽", Duration = "1 час" },
            new Service { Id = 2, Name = "Педикюр", Category = "Педикюр", Price = "1500₽", Duration = "1.5 часа" }
        };
        _serviceRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(services);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var dto = Assert.IsAssignableFrom<IEnumerable<ServiceDto>>(okResult.Value);
        Assert.Equal(2, dto.Count());
    }

    [Fact]
    public async Task Get_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var service = new Service { Id = 1, Name = "Маникюр", Category = "Маникюр", Price = "1000₽", Duration = "1 час" };
        _serviceRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(service);

        // Act
        var result = await _controller.Get(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var dto = Assert.IsType<ServiceDto>(okResult.Value);
        Assert.Equal("Маникюр", dto.Name);
    }

    [Fact]
    public async Task Get_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        _serviceRepoMock.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Service?)null);

        // Act
        var result = await _controller.Get(999);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Create_ValidDto_ReturnsCreatedAtAction()
    {
        // Arrange
        var dto = new ServiceCreateDto { Name = "Стрижка", Category = "Стрижки", Price = "1200₽", Duration = "1 час" };
        _serviceRepoMock.Setup(r => r.AddAsync(It.IsAny<Service>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _controller.Create(dto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var createdDto = Assert.IsType<ServiceDto>(createdResult.Value);
        Assert.Equal("Стрижка", createdDto.Name);
    }

    [Fact]
    public async Task Delete_ExistingId_ReturnsNoContent()
    {
        // Arrange
        var service = new Service { Id = 1, Name = "Маникюр", Category = "Маникюр", Price = "1000₽", Duration = "1 час" };
        _serviceRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(service);
        _unitOfWorkMock.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
