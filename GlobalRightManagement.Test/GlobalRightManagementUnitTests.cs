using System;
using System.Collections.Generic;
using GlobalRightManagement.Business;
using GlobalRightManagement.DataAccess;
using Moq;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    public class GlobalRightManagementUnitTests
    {
        private Mock<IContractsDataAccess> _contractsDataAccess;
        private IGlobalRightManagement _sut;

        [SetUp]
        public void SetUp()
        {
            _contractsDataAccess = new Mock<IContractsDataAccess>(MockBehavior.Strict);

            var partnerContract = new DistributionPartnerContract();
            _contractsDataAccess
                .Setup(x => x.GetDistributionPartnerContract(It.IsAny<string>()))
                .Returns(partnerContract);

            _contractsDataAccess
                .Setup(x => x.GetMusicContracts(partnerContract.Usage))
                .Returns(new List<MusicContract>());

            _sut = new Business.GlobalRightManagement(_contractsDataAccess.Object);
        }

        [Test]
        public void GivenAPartnerNameAndEffectiveDateWhenNoResultWasFoundItShouldReturnAnEmptyListOfMusicContracts()
        {
            var actual = _sut.GetActiveMusicContracts(It.IsAny<string>(), It.IsAny<DateTime>());

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Empty);
        }
    }
}