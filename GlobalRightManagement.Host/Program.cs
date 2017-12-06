using System;
using CommandLine;
using GlobalRightManagement.Business;

namespace GlobalRightManagement.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var options = new CommandLineOptions();
                if (Parser.Default.ParseArguments(args, options))
                {
                    Console.WriteLine(
                        $"Active applicable contracts for:\n\r Partner Name: {options.DeliveryPartnerName} \r\n Effective date: {options.EffectiveDdate.ToShortDateString()}\r\n");

                    var globalRightManagement = ObjectFactory.CreateGlobalRightManagement();
                    var activeMusicContracts =
                        globalRightManagement.GetActiveMusicContracts(options.DeliveryPartnerName,
                            options.EffectiveDdate);

                    foreach (var contract in activeMusicContracts)
                    {
                        Console.WriteLine(contract.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("\r\nPlease provide correct input as described above.");
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            Console.WriteLine("\r\nPress Enter to exit.");
            Console.ReadLine();
        }
    }
}