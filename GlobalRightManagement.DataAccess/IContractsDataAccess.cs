using System.Collections.Generic;

namespace GlobalRightManagement.DataAccess
{
    public interface IContractsDataAccess
    {
        DistributionPartnerContract GetDistributionPartnerContract(string partnerName);
        IEnumerable<MusicContract> GetMusicContracts(string usage);
    }
}