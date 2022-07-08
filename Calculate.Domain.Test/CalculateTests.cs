namespace Desafio.Domain.Test
{
    public class CalculateTests
    {
        [Fact]
        public void ShouldCalculateFinalValue()
        {
            // Arrange
            double initialValue = 100;
            byte months = 5;
            string fee = "0.01";
            string expectedResult = "105,10";

            // Act
            var calculate = new Calculate.Domain.Calculate(
                fee,
                months,
                initialValue
            );

            // Assert
            Assert.NotNull(calculate);
            Assert.Equal(expectedResult, calculate.Result);
        }
    }
}