using GlobalRightManagement.DataAccess;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    [TestFixture]
    public class ContractsDataAccessTests
    {
        private IContractsDataAccess _sut;

        [Test]
        public void ShouldReturnNullGivenAnEmptyStringAsNameofADistributionPartner()
        {
            _sut = new ContractsDataAccess();
            var actual = _sut.GetDistributionPartnerContract(string.Empty);

            Assert.That(actual, Is.Null);
        }
    }
}