namespace GlobalRightManagement.DataAccess.Domain
{
    public class DistributionPartnerContract : IDesrializeFromText<DistributionPartnerContract>
    {
        public string PartnerName { get; set; }
        public string Usage { get; set; }

        public DistributionPartnerContract DeserializeFromText(string line, char delimeter)
        {
            var fields = line.Split(delimeter);
            var contract = new DistributionPartnerContract
            {
                PartnerName = fields[0].Trim(),
                Usage = fields[1].Trim()
            };

            return contract;
        }
    }
}