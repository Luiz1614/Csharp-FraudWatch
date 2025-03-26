using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.Repositories.Interfaces;
using Moq;

namespace FraudWatch.Tests.Repositories;

public class DentistaRepositoryTest
{
    private readonly Mock<IDentistaRepository> _mockRepository;

    public DentistaRepositoryTest()
    {
        _mockRepository = new Mock<IDentistaRepository>();
    }

    [Fact]
    public void ShouldGetAllDentistas()
    {
        // Arrange
        var dentista = new DentistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            CRO = "SP123456",
            Email = "joao@email.com",
            Nome = "João Silva"
        };

        var dentistas = new List<DentistaEntity>
        {
            dentista
        };

        _mockRepository.Setup(x => x.GetAllDentistas()).Returns(dentistas);

        // Act

        var result = _mockRepository.Object.GetAllDentistas();

        // Assert

        Assert.NotNull(result);
        Assert.Equal(dentistas, result);
    }

    [Fact]
    public void ShouldGetDentistaById()
    {
        //Arrange
        var dentista = new DentistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            CRO = "SP123456",
            Email = "joao@email.com",
            Nome = "João Silva"
        };

        var dentistas = new List<DentistaEntity>
        {
            dentista
        };

        _mockRepository.Setup(x => x.GetDentistaById(1)).Returns(dentista);

        //act
        var result = _mockRepository.Object.GetDentistaById(1);

        //Assert

        Assert.NotNull(result);
        Assert.Equal(dentista.UsuarioId, result.UsuarioId);
    }

    [Fact]
    public void ShouldGetDentistaByCro()
    {
        //arrange
        var dentista = new DentistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            CRO = "SP123456",
            Email = "joao@email.com",
            Nome = "João Silva"
        };

        var dentistas = new List<DentistaEntity>
        {
            dentista
        };

        _mockRepository.Setup(x => x.GetDentistaByCro("SP123456")).Returns(dentista);

        //act
        var result = _mockRepository.Object.GetDentistaByCro("SP123456");

        //assert
        Assert.NotNull(result);
        Assert.Equal(dentista.CRO, result.CRO);
    }

    [Fact]
    public void ShoudAddDentista()
    {
        //arrange
        var dentista = new DentistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            CRO = "SP123456",
            Email = "joao@email.com",
            Nome = "João Silva"
        };

        _mockRepository.Setup(x => x.AddDentista(dentista));

        //act
        _mockRepository.Object.AddDentista(dentista);

        //assert
        _mockRepository.Verify(x => x.AddDentista(dentista), Times.Once);
    }

    [Fact]
    public void ShoudUpdateDentista()
    {
        var dentista = new DentistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            CRO = "SP123456",
            Email = "joao@email.com",
            Nome = "João Silva"
        };

        _mockRepository.Setup(x => x.UpdateDentistaById(1, dentista));

        //act

        _mockRepository.Object.UpdateDentistaById(1, dentista);

        //assert

        _mockRepository.Verify(x => x.UpdateDentistaById(1, dentista), Times.Once);
    }

    [Fact]
    public void ShouldDeleteDentista()
    {
        var dentista = new DentistaEntity
        {
            UsuarioId = 1,
            CPF = "12345678901",
            DataNascimento = new DateOnly(1990, 01, 01),
            CRO = "SP123456",
            Email = "joao@email.com",
            Nome = "João Silva"
        };

        _mockRepository.Setup(x => x.DeleteDentistaById(1));

        //act

        _mockRepository.Object.DeleteDentistaById(1);

        //assert

        _mockRepository.Verify(x => x.DeleteDentistaById(1), Times.Once);
    }
}

