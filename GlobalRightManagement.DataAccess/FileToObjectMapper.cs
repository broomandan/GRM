using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobalRightManagement.DataAccess
{
    internal class FileToObjectMapper<T> where T : IDesrializeFromText<T>, new()
    {
        private char _delimiter;

        public FileToObjectMapper(char delimiter1)
        {
            _delimiter = delimiter1;
        }

        public IList<T> Read(string fileFullName, bool includesHeader)
        {
            var startline = includesHeader ? 1 : 0;
            return File.ReadAllLines(fileFullName)
                .Skip(startline)
                .Select(line => (new T()).DeserializeFromText(line, _delimiter))
                .ToList();
        }
    }
}