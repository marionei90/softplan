using Microsoft.AspNetCore.Mvc.Testing;

namespace Integration.Test
{
    public class IntegrationTests
    {
        [Fact]
        public async Task ShouldCallFeesAndCalculateResult()
        {
            // Arrange
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            string expectedResult = "105,10";
            string expectedFee = "0.01";
            double initialValue = 100;
            byte months = 5;

            // Act
            var response = await httpClient.GetAsync("ReturnFees/taxaJuros");
            var fee = await response.Content.ReadAsStringAsync();

            var calculate = new Calculate.Domain.Calculate(
                fee,
                months,
                initialValue
            );

            // Assert
            Assert.Equal(expectedFee, fee);
            Assert.Equal(expectedResult, calculate.Result);
        }
    }
}