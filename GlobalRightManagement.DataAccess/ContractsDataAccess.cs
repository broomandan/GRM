using System.Collections.Generic;

namespace GlobalRightManagement.DataAccess
{
    internal class ContractsDataAccess : IContractsDataAccess
    {
        public DistributionPartnerContract GetDistributionPartnerContract(string partnerName)
        {
            return null;
        }

        public IEnumerable<MusicContract> GetMusicContracts(string usage)
        {
            return new List<MusicContract>();
        }
    }
}