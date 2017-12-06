using System.Collections.Generic;
using GlobalRightManagement.DataAccess;
using GlobalRightManagement.DataAccess.Domain;
using Moq;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    [TestFixture]
    public class DistributionPartnerDataAccessUnitTests
    {
        private IDistributionPartnerDataAccess _sut;
        private Mock<IFileToObjectMapper<DistributionPartnerContract>> _fileToObjectMapper;

        [SetUp]
        public void SetUp()
        {
            _fileToObjectMapper = new Mock<IFileToObjectMapper<DistributionPartnerContract>>(MockBehavior.Strict);
            _fileToObjectMapper
                .Setup(x => x.Read(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new List<DistributionPartnerContract>());

            _sut = new DistributionPartnerDataAccess(_fileToObjectMapper.Object);
        }

        [Test]
        public void ShouldReturnNullGivenAnEmptyStringAsNameofADistributionPartner()
        {
            var actual = _sut.GetDistributionPartnerContract(string.Empty);

            Assert.That(actual, Is.Null);
            _fileToObjectMapper.VerifyAll();
        }

        [Test]
        public void ShouldReturnListOfPartnerContractsGivenAVallidDistributionPartnerName()
        {
            _fileToObjectMapper
                .Setup(x => x.Read(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new List<DistributionPartnerContract>
                {
                    new DistributionPartnerContract
                    {
                        PartnerName = "ABC",
                        Usage = "streaming"
                    },

                    new DistributionPartnerContract
                    {
                        PartnerName = "DEF",
                        Usage = "digital  download"
                    }
                });


            var actual = _sut.GetDistributionPartnerContract("ABC");

            Assert.That(actual.Usage, Is.EqualTo("streaming"));
            _fileToObjectMapper.VerifyAll();
        }
    }
}