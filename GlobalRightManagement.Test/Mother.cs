using System.Collections;
using System.Collections.Generic;

namespace GlobalRightManagement.Test
{
    public class Mother
    {
        public static IList ExpectedTitleListInOrderForScenario1 => new List<string>
        {
            "Black Mountain",
            "Motor Mouth",
            "Frisky (Live from SoHo)",
            "Miami 2 Ibiza"
        };

        public static string ExpectedUsageForScenario1 => "digital download";

        public static IEnumerable<string> ExpectedTitleListInOrderForScenario2 => new List<string>
        {
            "Christmas Special",
            "Iron Horse",
            "Motor Mouth",
            "Frisky (Live from SoHo)"
        };

        public static IEnumerable<string> ExpectedArtistListInOrderForScenario3 =>
            new List<string> {"Monkey Claw", "Tinie Tempah"};
    }
}