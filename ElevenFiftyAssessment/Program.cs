using System;

namespace ElevenFiftyAssessment
{
    class Program
    {

        static string MakeString(string s, decimal d)
        {
            return $"This is a string {s} and a decimal {d}";
        }

        static void Main(string[] args)
        {

            int i = 5;
            bool b = true;
            string s = "foo bar";
            double dbl = 5.02;
            decimal d = 5.2M;

            Console.WriteLine(MakeString(s, d));

            var names = new[] { "one" ,"two", "three", "four"};

            foreach (var n in names)
            {
                Console.WriteLine(n);
            }

            //var c = new Customer("Dave", Gender.Male, "iphone");
            //var ic = new InactiveCustomer("Jen", Gender.Female, "android", 4);
            //var ic2 = new InactiveCustomer("James", Gender.Male, "android", 5)
            //{
            //    InactiveReason = InactiveReason.Moved
            //};


            //c.SayThankYou();
            //Console.WriteLine();
            //c.SendSaleNotice(DateTime.Now.AddDays(5));

            //Console.WriteLine();
            //c.SendSaleNotice(DateTime.Now.AddDays(5), "some other product");

            //c.PrintCustomerInfo();

            //Console.WriteLine();

            //// Should not send notice
            //ic.SendInactivityMessage();

            //ic.PrintCustomerInfo();
            //Console.WriteLine();

            //// Should send notice
            //ic2.SendInactivityMessage();
            //ic2.PrintCustomerInfo();




            Console.ReadLine();

        }
    }
}
