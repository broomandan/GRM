using System;
using CommandLine;

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
                        $"Active applicable contracts for delivery partner: {options.DeliveryPartnerName} for effective date of: {options.EffectiveDdate.ToShortDateString()}");

                    Console.WriteLine("List of active contracts");


                }
                else
                {
                    Console.WriteLine("Please provide correct input as described above.");
                }
                
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}