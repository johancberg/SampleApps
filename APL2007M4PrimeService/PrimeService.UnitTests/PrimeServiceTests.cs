using Xunit;
using System.Numbers;

namespace PrimeService.UnitTests
{
    public class PrimeServiceTests
    {
        private readonly PrimeService _primeService;

        public PrimeServiceTests()
        {
            _primeService = new PrimeService();
        }

        [Fact]
        public void IsPrime_InputIsLessThan2_ReturnsFalse()
        {
            Assert.False(_primeService.IsPrime(1));
            Assert.False(_primeService.IsPrime(0));
            Assert.False(_primeService.IsPrime(-1));
        }

        [Fact]
        public void IsPrime_InputIsPrime_ReturnsTrue()
        {
            Assert.True(_primeService.IsPrime(2));
            Assert.True(_primeService.IsPrime(3));
            Assert.True(_primeService.IsPrime(5));
            Assert.True(_primeService.IsPrime(7));
            Assert.True(_primeService.IsPrime(11));
        }

        [Fact]
        public void IsPrime_InputIsNotPrime_ReturnsFalse()
        {
            Assert.False(_primeService.IsPrime(4));
            Assert.False(_primeService.IsPrime(6));
            Assert.False(_primeService.IsPrime(8));
            Assert.False(_primeService.IsPrime(9));
            Assert.False(_primeService.IsPrime(10));
        }
    }
}