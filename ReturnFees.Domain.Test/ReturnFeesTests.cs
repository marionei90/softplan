namespace ReturnFees.Domain.Test
{
    public class ReturnFeesTests
    {
        [Fact]
        public void ShouldReturnFixedFee()
        {
            // Arrange
            var expectedFee = 0.01;

            // Act
            var fee = new ReturnFee();

            // Assert
            Assert.NotNull(fee);
            Assert.Equal(expectedFee, fee.Fee);
        }
    }
}