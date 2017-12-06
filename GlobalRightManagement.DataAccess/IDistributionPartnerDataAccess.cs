using GlobalRightManagement.DataAccess.Domain;

namespace GlobalRightManagement.DataAccess
{
    public interface IDistributionPartnerDataAccess
    {
        DistributionPartnerContract GetDistributionPartnerContract(string partnerName);
    }
}