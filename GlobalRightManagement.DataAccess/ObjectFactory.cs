using GlobalRightManagement.DataAccess.Domain;

namespace GlobalRightManagement.DataAccess
{
    public class ObjectFactory
    {
        public static IRecordLabelDataAccess CreateRecordLabelDataAccess()
        {
            return new RecordLabelDataAccess(new FileToObjectMapper<MusicContract>('|'));
        }

        public static IDistributionPartnerDataAccess CreateDistributionPartnerDataAccess()
        {
            return new DistributionPartnerDataAccess(new FileToObjectMapper<DistributionPartnerContract>('|'));
        }
    }
}