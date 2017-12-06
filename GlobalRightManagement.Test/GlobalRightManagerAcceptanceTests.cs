using System;
using System.Linq;
using GlobalRightManagement.Business;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    [TestFixture]
    public class GlobalRightManagerAcceptanceTests
    {
        private IGlobalRightManager _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = ObjectFactory.CreateGlobalRightManagement();
        }

        [Test]
        public void ShouldReturnExpectedActiveMusicContractsGivenInput1()
        {
            var actual = _sut.GetActiveMusicContracts("ITunes", new DateTime(2012, 3, 1));

            Assert.That(actual.Count(), Is.EqualTo(4));
            Assert.True(actual.All(contract =>
                contract.Usages.Any(usage => usage == Mother.ExpectedUsageForScenario1)));

            var titles = actual.Select(contract => contract.Title);
            CollectionAssert.AreEqual(titles, Mother.ExpectedTitleListInOrderForScenario1);
        }

        [Test]
        public void ShouldReturnExpectedActiveMusicContractsGivenInput2()
        {
            var actual = _sut.GetActiveMusicContracts("YouTube", new DateTime(2012, 12, 27));

            Assert.That(actual.Count(), Is.EqualTo(4));

            var firstContract = actual.First();
            var lastContract = actual.Last();

            Assert.That(firstContract.Artist, Is.EqualTo("Monkey Claw"));
            Assert.That(firstContract.StartDate, Is.EqualTo(new DateTime(2012, 12, 25)));
            Assert.That(firstContract.EndDate, Is.EqualTo(new DateTime(2012, 12, 31)));

            Assert.That(lastContract.Artist, Is.EqualTo("Tinie Tempah"));

            var titles = actual.Select(contract => contract.Title);
            CollectionAssert.AreEqual(titles, Mother.ExpectedTitleListInOrderForScenario2);
        }

        [Test]
        public void ShouldReturnExpectedActiveMusicContractsGivenInput3()
        {
            var actual = _sut.GetActiveMusicContracts("YouTube", new DateTime(2012, 4, 1));

            var artists = actual.Select(contract => contract.Artist);
            CollectionAssert.AreEqual(artists, Mother.ExpectedArtistListInOrderForScenario3);
        }
    }
}