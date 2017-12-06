namespace GlobalRightManagement.DataAccess
{
    //Assumption: Each partner is only in contract with one and only one usage 

    public class DistributionPartnerContract : IDesrializeFromText<DistributionPartnerContract>
    {
        public string PartnerName { get; set; }
        public string Usage { get; set; }

        public DistributionPartnerContract DeserializeFromText(string line, char delimeter)
        {
            var fields = line.Split(delimeter);
            var contract = new DistributionPartnerContract
            {
                PartnerName = fields[0],
                Usage = fields[1]
            };

            return contract;
        }
    }
}