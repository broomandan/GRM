using System.Collections.Generic;
using NUnit.Framework;

namespace GlobalRightManagement.Test
{
    public class GlobalRightManagementUnitTests
    {
        [Test]
        public void ShouldSearchForDeliveryPartnerActiveContractsGivenAPartnerNameAndEffectiveDate()
        {
            IGlobalRightManagement sut = new GlobalRightManagement();
            sut.GetActiveMusicContracts();
        }
    }

    public interface IGlobalRightManagement
    {
        IEnumerable<MusicContract> GetActiveMusicContracts();
    }

    public class MusicContract
    {
    }

    class GlobalRightManagement : IGlobalRightManagement
    {
        public IEnumerable<MusicContract> GetActiveMusicContracts()
        {
            return new List<MusicContract>();
        }
    }
}