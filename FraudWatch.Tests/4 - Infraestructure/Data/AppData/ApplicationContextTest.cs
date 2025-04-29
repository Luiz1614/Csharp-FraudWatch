using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace FraudWatch.Tests.AppData;

public class ApplicationContextTests
{
    private DbContextOptions<ApplicationContext> GetInMemoryOptions()
    {
        return new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public void CanAddAndRetrieveAnalista()
    {
        // Arrange
        var options = GetInMemoryOptions();
        using (var context = new ApplicationContext(options))
        {
            var analista = new AnalistaEntity
            {
                Nome = "Test Analista",
                Email = "analista@test.com",
                CPF = "12345678900",
                DataNascimento = new DateOnly(1990, 1, 1),
                Departamento = "Test Department"
            };

            // Act
            context.Analistas.Add(analista);
            context.SaveChanges();
        }

        // Assert
        using (var context = new ApplicationContext(options))
        {
            var analista = context.Analistas.FirstOrDefault(a => a.Email == "analista@test.com");
            Assert.NotNull(analista);
            Assert.Equal("Test Analista", analista.Nome);
        }
    }
}
