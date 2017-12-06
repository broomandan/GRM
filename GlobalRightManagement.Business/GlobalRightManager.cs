using System;
using System.Collections.Generic;
using System.Linq;
using GlobalRightManagement.DataAccess;
using GlobalRightManagement.DataAccess.Domain;

namespace GlobalRightManagement.Business
{
    public class GlobalRightManager : IGlobalRightManager
    {
        private readonly IDistributionPartnerDataAccess _distributionPartnerDataAccess;
        private readonly IRecordLabelDataAccess _recordLabelDataAccess;

        public GlobalRightManager(IDistributionPartnerDataAccess distributionPartnerDataAccess,
            IRecordLabelDataAccess recordLabelDataAccess)
        {
            _distributionPartnerDataAccess = distributionPartnerDataAccess;
            _recordLabelDataAccess = recordLabelDataAccess;
        }

        public IEnumerable<MusicContract> GetActiveMusicContracts(string deliveryPartnerName, DateTime effecDateTime)
        {
            var partnerContract = _distributionPartnerDataAccess.GetDistributionPartnerContract(deliveryPartnerName);
            var musicContracts = _recordLabelDataAccess.GetMusicContracts(partnerContract.Usage);
            return musicContracts
                .Where(EffectiveDatePredicate(effecDateTime))
                .OrderBy(contract => contract.Artist)
                .ThenByDescending(contract => contract.EndDate);
        }

        private static Func<MusicContract, bool> EffectiveDatePredicate(DateTime effecDateTime)
        {
            return contract =>
            {
                if (!contract.EndDate.HasValue)
                {
                    return contract.StartDate <= effecDateTime;
                }
                return contract.StartDate <= effecDateTime && effecDateTime <= contract.EndDate;
            };
        }
    }
}