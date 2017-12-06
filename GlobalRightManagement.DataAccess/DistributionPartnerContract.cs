namespace GlobalRightManagement.DataAccess
{
    public class DistributionPartnerContract //Assumption: Each partner is only in contract with one and only one usage 
    {
        public string PartnerName { get; set; }
        public Usage Usage { get; set; }
    }
}