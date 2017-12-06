using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalRightManagement.DataAccess.Domain
{
    public class MusicContract : IDesrializeFromText<MusicContract>
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public IList<string> Usages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public MusicContract DeserializeFromText(string line, char delimeter)
        {
            var fields = line.Split(delimeter);
            var contract = new MusicContract()
            {
                Artist = fields[0].Trim(),
                Title = fields[1].Trim(),
                Usages = Array.ConvertAll(fields[2].Trim().Split(','), u => u.Trim()),
                StartDate = Convert.ToDateTime(fields[3]),
                EndDate = MapEndDate(fields)
            };

            return contract;
        }

        public override string ToString()
        {
            var endDate = EndDate?.ToShortDateString() ?? string.Empty;
            return $" {Artist} | {Title} | {string.Join(",", Usages)} | {StartDate.ToShortDateString()} | {endDate}";
        }

        private static DateTime? MapEndDate(IReadOnlyList<string> fields)
        {
            DateTime? result = null;
            if (!string.IsNullOrEmpty(fields[4]))
            {
                result = Convert.ToDateTime(fields[4]);
            }
            return result;
        }
    }
}