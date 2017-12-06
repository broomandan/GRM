using System;
using System.Collections.Generic;
using GlobalRightManagement.DataAccess;

namespace GlobalRightManagement.Business
{
    public interface IGlobalRightManagement
    {
        IEnumerable<MusicContract> GetActiveMusicContracts(string deliveryPartnerName, DateTime effecDateTime);
    }
}