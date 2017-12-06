using System.Collections.Generic;
using GlobalRightManagement.DataAccess.Domain;

namespace GlobalRightManagement.DataAccess
{
    public interface IRecordLabelDataAccess
    {
        IEnumerable<MusicContract> GetMusicContracts(string usage);
    }
}