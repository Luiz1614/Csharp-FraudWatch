using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.Repositories.Interfaces;
using Moq;

namespace FraudWatch.Tests.Repositories;

public class AnalistaRepositoryTests
{
    private readonly Mock<IAnalistaRepository> _mockRepository;

    public AnalistaRepositoryTests()
    {
        _mockRepository = new Mock<IAnalistaRepository>();
    }

    [Fact]
    public void ShouldGetAllAnalistas()
    {
        // Arrange
        var analista = new AnalistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            Departamento = "TI",
            Email = "roberto@email.com",
            Nome = "Roberto Carlos"
        };

        var analistas = new List<AnalistaEntity>
        {
            analista
        };

        _mockRepository.Setup(x => x.GetAllAnalistas()).Returns(analistas);

        // Act
        var result = _mockRepository.Object.GetAllAnalistas();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(analistas, result);
    }

    [Fact]
    public void ShouldGetAnalistaById()
    {
        // Arrange
        var analista = new AnalistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            Departamento = "TI",
            Email = "roberto@email.com",
            Nome = "Roberto Carlos"
        };

        var analistas = new List<AnalistaEntity>
        {
            analista
        };

        _mockRepository.Setup(x => x.GetAnalistaById(1)).Returns(analista);

        // Act
        var result = _mockRepository.Object.GetAnalistaById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(analista.UsuarioId, result.UsuarioId);
    }

    [Fact]
    public void ShouldGetAnalistaByDepartamento()
    {
        // Arrange
        var analista = new AnalistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            Departamento = "TI",
            Email = "roberto@email.com",
            Nome = "Roberto Carlos"
        };

        var analistas = new List<AnalistaEntity>
        {
            analista
        };

        _mockRepository.Setup(x => x.GetAnalistaByDepartamento("TI")).Returns(analista);

        // Act
        var result = _mockRepository.Object.GetAnalistaByDepartamento("TI");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(analista.Departamento, result.Departamento);
    }

    [Fact]
    public void ShouldAddAnalista()
    {
        //arrange
        var analista = new AnalistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            Departamento = "TI",
            Email = "roberto@email.com",
            Nome = "Roberto Carlos"
        };

        _mockRepository.Setup(x => x.AddAnalista(analista));

        //act
        _mockRepository.Object.AddAnalista(analista);

        //assert
        _mockRepository.Verify(x => x.AddAnalista(analista), Times.Once);
    }

    [Fact]
    public void ShouldUpdateAnalista()
    {
        //arrange
        var analista = new AnalistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            Departamento = "TI",
            Email = "roberto@email.com",
            Nome = "Roberto Carlos"
        };

        _mockRepository.Setup(x => x.UpdateAnalistaByID(1, analista));

        //act
        _mockRepository.Object.UpdateAnalistaByID(1, analista);

        //assert
        _mockRepository.Verify(x => x.UpdateAnalistaByID(1, analista), Times.Once);
    }

    [Fact]
    public void ShouldDeleteAnalista()
    {
        //arrange
        var analista1 = new AnalistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            Departamento = "TI",
            Email = "roberto@email.com",
            Nome = "Roberto Carlos"
        };

        _mockRepository.Setup(x => x.DeleteAnalistaById(1));

        //act
        _mockRepository.Object.DeleteAnalistaById(1);

        //assert
        _mockRepository.Verify(x => x.DeleteAnalistaById(1), Times.Once);
    }
}
