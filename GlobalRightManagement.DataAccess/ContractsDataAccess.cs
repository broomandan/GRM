using System;
using System.Collections.Generic;

namespace GlobalRightManagement.DataAccess
{
    internal class ContractsDataAccess : IContractsDataAccess
    {
        public DistributionPartnerContract GetDistributionPartnerContract(string partnerName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MusicContract> GetMusicContracts(Usage usage)
        {
            throw new NotImplementedException();
        }
    }
}