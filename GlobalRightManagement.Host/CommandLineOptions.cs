using System;
using CommandLine;
using CommandLine.Text;

namespace GlobalRightManagement.Host
{
    internal class CommandLineOptions
    {
        [Option('p', "DeliveryPartnerName", Required = true, HelpText = "Delivery Partner Name to be looked up.")]
        public string DeliveryPartnerName { get; set; }

        [Option('d', "Date", Required = true, HelpText = "Effective date, in mm/dd/yyyy format")]
        public DateTime EffectiveDdate { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}