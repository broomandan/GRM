using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalRightManagement.DataAccess.Domain;

namespace GlobalRightManagement.DataAccess
{
    internal class RecordLabelDataAccess : IRecordLabelDataAccess
    {
        private const string MusicContractsPath = @"DataFiles\MusicContracts.txt";
        private readonly IFileToObjectMapper<MusicContract> _fileToObjectMapper;

        public RecordLabelDataAccess(IFileToObjectMapper<MusicContract> fileToObjectMapper)
        {
            _fileToObjectMapper = fileToObjectMapper;
        }

        public IEnumerable<MusicContract> GetMusicContracts(string usage)
        {
            var fileFullName =
                Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, MusicContractsPath);

            var musicContracts = _fileToObjectMapper.Read(fileFullName, true);

            return musicContracts
                .Where(contract => contract.Usages.Contains(usage));
        }
    }
}