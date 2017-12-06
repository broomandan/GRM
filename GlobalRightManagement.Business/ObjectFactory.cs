namespace GlobalRightManagement.Business
{
    public class ObjectFactory
    {
        public static IGlobalRightManager CreateGlobalRightManagement()
        {
            return new GlobalRightManager(
                DataAccess.ObjectFactory.CreateDistributionPartnerDataAccess(),
                DataAccess.ObjectFactory.CreateRecordLabelDataAccess());
        }
    }
}