using System;
using System.Collections.Generic;
using GlobalRightManagement.DataAccess.Domain;

namespace GlobalRightManagement.Business
{
    public interface IGlobalRightManager
    {
        IEnumerable<MusicContract> GetActiveMusicContracts(string deliveryPartnerName, DateTime effecDateTime);
    }
}