using System;
using System.Collections.Generic;
using GlobalRightManagement.DataAccess;

namespace GlobalRightManagement.Business
{
    public class GlobalRightManagement : IGlobalRightManagement
    {
        private readonly IContractsDataAccess _contractsDataAccess;

        public GlobalRightManagement(IContractsDataAccess contractsDataAccess)
        {
            _contractsDataAccess = contractsDataAccess;
        }

        public IEnumerable<MusicContract> GetActiveMusicContracts(string deliveryPartnerName, DateTime effecDateTime)
        {
            var partnerContract =
                _contractsDataAccess
                    .GetDistributionPartnerContract(
                        deliveryPartnerName); //TODO: These two calls could be optimized dependeing on size of containing tables
            var musicContracts = _contractsDataAccess.GetMusicContracts(partnerContract.Usage);
            return musicContracts;
        }
    }
}