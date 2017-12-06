using System;
using System.Collections.Generic;

namespace GlobalRightManagement.DataAccess
{
    public class MusicContract : IDesrializeFromText<MusicContract>
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public IList<string> Usages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MusicContract DeserializeFromText(string line, char delimeter)
        {
            var fields = line.Split(delimeter);
            var contract = new MusicContract()
            {
                Artist = fields[0],
                Title = fields[1],
                Usages = fields[2].Split(','),
                StartDate = Convert.ToDateTime(fields[3]),
                EndDate = !string.IsNullOrEmpty(fields[4]) ? Convert.ToDateTime(fields[4]) : DateTime.MaxValue
            };

            return contract;
        }
    }
}