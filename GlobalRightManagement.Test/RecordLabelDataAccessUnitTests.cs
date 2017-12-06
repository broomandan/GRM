using System.Collections.Generic;
using System.Linq;
using GlobalRightManagement.DataAccess;
using GlobalRightManagement.DataAccess.Domain;
using Moq;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    [TestFixture()]
    public class RecordLabelDataAccessUnitTests
    {
        private IRecordLabelDataAccess _sut;
        private Mock<IFileToObjectMapper<MusicContract>> _fileToObjectMapper;

        [SetUp]
        public void SetUp()
        {
            _fileToObjectMapper = new Mock<IFileToObjectMapper<MusicContract>>(MockBehavior.Strict);

            _sut = new RecordLabelDataAccess(_fileToObjectMapper.Object);
        }

        [Test]
        public void ShouldReturnAnEmptyListGivenAnEmptyUsage()
        {
            _fileToObjectMapper
                .Setup(x => x.Read(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new List<MusicContract>());

            var actual = _sut.GetMusicContracts(string.Empty);
            Assert.That(actual.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnASingleResultGivenAUsageThatIsUsedInOneContract()
        {
            _fileToObjectMapper
                .Setup(x => x.Read(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new List<MusicContract>
                    {
                        new MusicContract
                        {
                            Usages = new List<string> {"streaming"}
                        },
                        new MusicContract
                        {
                            Usages = new List<string> {"download"}
                        }
                    }
                );

            var actual = _sut.GetMusicContracts("streaming");
            Assert.That(actual.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnASingleResultGivenAUsageWhenUsageIsPartOfAMultiUsageContract()
        {
            var expectedUsage = "download";

            _fileToObjectMapper
                .Setup(x => x.Read(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new List<MusicContract>
                    {
                        new MusicContract
                        {
                            Usages = new List<string> {"streaming"}
                        },
                        new MusicContract
                        {
                            Usages = new List<string> {"streaming", expectedUsage}
                        }
                    }
                );

            var actual = _sut.GetMusicContracts(expectedUsage);

            Assert.That(actual.Count(), Is.EqualTo(1));
            Assert.That(actual.First().Usages.Last(), Is.EqualTo(expectedUsage));
        }

        [Test]
        public void ShouldReturnListOfContractGivenAUsageWhenUsageIsUsedInMultipleContracts()
        {
            var expectedUsage = "streaming";

            _fileToObjectMapper
                .Setup(x => x.Read(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new List<MusicContract>
                    {
                        new MusicContract
                        {
                            Usages = new List<string> {expectedUsage}
                        },
                        new MusicContract
                        {
                            Usages = new List<string> {expectedUsage, "download"}
                        }
                    }
                );

            var actual = _sut.GetMusicContracts(expectedUsage);

            Assert.That(actual.Count(), Is.EqualTo(2));
            Assert.That(actual.First().Usages.First(), Is.EqualTo(expectedUsage));
        }
    }
}