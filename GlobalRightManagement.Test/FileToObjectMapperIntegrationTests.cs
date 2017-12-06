using System.IO;
using System.Linq;
using GlobalRightManagement.DataAccess;
using GlobalRightManagement.DataAccess.Domain;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    [TestFixture]
    public class FileToObjectMapperIntegrationTests
    {
        [Test]
        public void ShouldReturnListOfPartnerConractsGivenATextFileWhichIncludesHeader()
        {
            var sut = new FileToObjectMapper<DistributionPartnerContract>('|');
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory,
                @"DataFiles\DistributionPartnerContracts.txt");
            var actual = sut.Read(path, true);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual.Count, Is.EqualTo(2));
            Assert.That(actual.First().Usage, Is.EqualTo("digital download"));
            Assert.That(actual.Last().Usage, Is.EqualTo("streaming"));
        }

        [Test]
        public void ShouldReturnListOfMusicConractsGivenATextFileWhichIncludesHeader()
        {
            var sut = new FileToObjectMapper<MusicContract>('|');
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory,
                @"DataFiles\MusicContracts.txt");
            var actual = sut.Read(path, true);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
        }

        [Test]
        public void
            ShouldReturnListOfMusicConractsWithoutLeadingSpacesGivenATextInputFileWithLeadingSpacesInUsage()
        {
            var sut = new FileToObjectMapper<MusicContract>('|');
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory,
                @"DataFiles\MusicContracts.txt");
            var actual = sut.Read(path, true);

            var firstMusicContract = actual.First();
            Assert.That(firstMusicContract.Usages.Count, Is.EqualTo(2));
            Assert.That(firstMusicContract.Usages.Last(), Is.EqualTo("streaming"));
        }
    }
}