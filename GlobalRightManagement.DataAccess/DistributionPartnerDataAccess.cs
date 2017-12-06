using System;
using System.IO;
using System.Linq;
using GlobalRightManagement.DataAccess.Domain;

namespace GlobalRightManagement.DataAccess
{
    internal class DistributionPartnerDataAccess : IDistributionPartnerDataAccess
    {
        private const string DistributionPartnerContractsPath = @"DataFiles\DistributionPartnerContracts.txt";
        private readonly IFileToObjectMapper<DistributionPartnerContract> _fileToObjectMapper;

        public DistributionPartnerDataAccess(IFileToObjectMapper<DistributionPartnerContract> fileToObjectMapper)
        {
            _fileToObjectMapper = fileToObjectMapper;
        }

        public DistributionPartnerContract GetDistributionPartnerContract(string partnerName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                DistributionPartnerContractsPath);
            var partnerContracts = _fileToObjectMapper.Read(path, true);
            //Assumption: Each partner is only in contract with one and only one usage 
            return partnerContracts
                .FirstOrDefault(
                    contract =>
                        contract.PartnerName.Equals(partnerName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}