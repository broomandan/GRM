using System.Collections.Generic;

namespace GlobalRightManagement.DataAccess
{
    public interface IFileToObjectMapper<T> where T : IDesrializeFromText<T>, new()
    {
        IList<T> Read(string fileFullName, bool includesHeader);
    }
}