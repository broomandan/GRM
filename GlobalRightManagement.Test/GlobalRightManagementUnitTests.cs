using System;
using System.Collections.Generic;
using GlobalRightManagement.Business;
using GlobalRightManagement.DataAccess;
using GlobalRightManagement.DataAccess.Domain;
using Moq;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    [TestFixture]
    public class GlobalRightManagementUnitTests
    {
        private Mock<IDistributionPartnerDataAccess> _contractsDataAccess;
        private Mock<IRecordLabelDataAccess> _recordLabelDataAccess;
        private IGlobalRightManager _sut;

        [SetUp]
        public void SetUp()
        {
            _contractsDataAccess = new Mock<IDistributionPartnerDataAccess>(MockBehavior.Strict);
            _recordLabelDataAccess = new Mock<IRecordLabelDataAccess>(MockBehavior.Strict);

            var partnerContract = new DistributionPartnerContract();
            _contractsDataAccess
                .Setup(x => x.GetDistributionPartnerContract(It.IsAny<string>()))
                .Returns(partnerContract);

            _recordLabelDataAccess
                .Setup(x => x.GetMusicContracts(partnerContract.Usage))
                .Returns(new List<MusicContract>());

            _sut = new GlobalRightManager(_contractsDataAccess.Object, _recordLabelDataAccess.Object);
        }

        [Test]
        public void ShouldReturnAnEmptyListOfMusicContractsGivenAPartnerNameAndEffectiveDateWhenNoResultWasFoundIt()
        {
            var actual = _sut.GetActiveMusicContracts(It.IsAny<string>(), It.IsAny<DateTime>());

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Empty);
            _contractsDataAccess.VerifyAll();
        }

        [Test]
        public void ShouldReturnAnEmptyListOfMusicContractsGivenAnEmptyPartnerNameAndAValidEffectiveDate()
        {
            var actual = _sut.GetActiveMusicContracts(string.Empty, DateTime.Now);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Empty);
            _contractsDataAccess.VerifyAll();
        }

        //TODO:Finish
        [Test]
        public void ShouldReturnListOfMusicContractsGivenAnPartnerNameAndAValidEffectiveDate()
        {
            _recordLabelDataAccess
                .Setup(x => x.GetMusicContracts(It.IsAny<string>()))
                .Returns(new List<MusicContract>());

            var actual = _sut.GetActiveMusicContracts(string.Empty, DateTime.Now);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Empty);
            _contractsDataAccess.VerifyAll();
        }
    }
}