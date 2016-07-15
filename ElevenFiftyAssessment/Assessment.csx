using System;

int i = 5;
bool b = true;
string s = "foo bar";
double dbl = 5.02;
decimal d = 5.2M;


static string MakeString(string s, decimal d)
{
    return $"This is a string {s} and a decimal {d}";
}

Console.WriteLine(MakeString(s, d));

var names = new[] { "one", "two", "three", "four" };

foreach (var n in names)
{
    Console.WriteLine(n);
}

/*
 * Part Two: OOP

Add an enum to the InactiveCustomer class that gives a couple reasons why a customer might not be purchasing. The reasons might be Irate, Moved, Uninterested

Add a property to the InactiveCustomer class that indicates why the customer is inactive

Add a method called PrintCustomerInfo that overrides the one from the Customer class. You should print Name, product purchased, gender, months inactive, and reason for inactivity. For example:

Michael - desk - Male - 4 - Moved
 * 
 * 
 */

//You should also create an Enum called Gender.
// The 0 spot should be Unknown, the 1 spot should be Male, and the 2 spot should be Female.
public enum Gender
{
    Unkown = 0,
    Male = 1,
    Female = 2
}

public class Customer
{
    // Create a class called Customer. The class should have three properties: Name, Gender, and Purchase.  

    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Purchase { get; set; }

    // Create a constructor for the Customer class that allows you to more easily create Customer objects.
    // The constructor should have parameters for name, gender, and purchase. Remember that gender will be an enum, so the enum name will be its type.

    public Customer(string name, Gender gender, string purchase)
    {
        Name = name;
        Gender = gender;
        Purchase = purchase;
    }


    /* 
    Create a method in your Customer class that simulates sending a thank you to the customer after their purchase by writing the message to the console.
    Your console message might read something like this:

    Hello {Name}, thank you for purchasing the {product}. We hope you enjoy it!
    */
    public void SayThankYou()
    {
        Console.WriteLine($"Hello {Name}, thank you for purchasing the {Purchase}. We hope you enjoy it !");
    }

    // Create two more methods.They should both be called SendSaleNotice.One should accept only a date as a parameter and the other one is an overload of
    //that same method which should accept both a date and a string as parameters.
    // Use these methods to announce sales. Your methods should print something similar to these messages:
    // Hello Dave, We wanted to let you know there's a sale coming up on 4/1/2016.
    // Hello Dave, We wanted to let you know there's a sale on Apple iPhones coming up on 4/1/2016.

    public void SendSaleNotice(DateTime saleDate)
    {
        Console.WriteLine($"Hello {Name}, we wanted to let you know there's a sale coming up on {saleDate:MM/dd/yyyy}");
    }

    public void SendSaleNotice(DateTime saleDate, string product)
    {
        Console.WriteLine($"Hello {Name}, we wanted to let you know there's a sale on {product} coming up {saleDate:MM/dd/yyyy}");
    }


    /*
        * Add an overridable method to the Customer class called PrintCustomerInfo. (hint: Virtual Modifier) The method should print the name purchase, and gender of the customer. It could go like this:
            Paul - Fender Jazz Bass Guitar - Male.
    */

    public virtual void PrintCustomerInfo()
    {
        Console.WriteLine($"{Name} - {Purchase} - {Gender}");
    }

}


/*
    * 
    * Create a subclass of Customer called InactiveCutomer. The class should have an int property called MonthsInactive, 
    * and other programmers SHOULD NOT be able to create subclasses from it. (hint: Sealed Modifier)

In the InactiveCustomer subclass, create a constructor that uses the base keyword that adds a monthsInactive parameter.

*/


public enum InactiveReason
{
    Irate = 0,
    Moved = 1,
    Uninterested = 2
}

public sealed class InactiveCustomer : Customer
{
    public InactiveCustomer(string name, Gender gender, string purchase, int monthsInactive) : base(name, gender, purchase)
    {
        MonthsInactive = monthsInactive;
    }

    public int MonthsInactive { get; set; }

    public InactiveReason InactiveReason { get; set; }


    // In the InactiveCustomer subclass create a method that sends a message to a customer who has been inactive for over four months.
    // The console would read something like this:

    //Thanks for shopping with us {Name}. We saw that you purchased an { product }
    //    from us { monthsInactive }
    //    months ago.
    //We'd like to know if you'd like to take a look at some of our current deals.
    //You should, of course, create instances of these classes, set the properties via the constructors, and test the methods on those objects.
    public void SendInactivityMessage()
    {
        if (MonthsInactive < 5) return;

        Console.WriteLine($"Thanks for shopping with us {Name}. It has been {MonthsInactive} months since you last made your purchase of {Purchase}.");
        Console.WriteLine("We'd like to know if you'd like to take a look at some of our current deals.");
    }

    public override void PrintCustomerInfo()
    {
        Console.WriteLine($"{Name} - {Purchase} - {Gender} - {MonthsInactive} - {InactiveReason}");
    }
}


var c = new Customer("Dave", Gender.Male, "iphone");
var ic = new InactiveCustomer("Jen", Gender.Female, "android", 4);
var ic2 = new InactiveCustomer("James", Gender.Male, "android", 5)
{
    InactiveReason = InactiveReason.Moved
};


c.SayThankYou();
Console.WriteLine();
c.SendSaleNotice(DateTime.Now.AddDays(5));

Console.WriteLine();
c.SendSaleNotice(DateTime.Now.AddDays(5), "some other product");

c.PrintCustomerInfo();

Console.WriteLine();

// Should not send notice
ic.SendInactivityMessage();

ic.PrintCustomerInfo();
Console.WriteLine();

// Should send notice
ic2.SendInactivityMessage();
ic2.PrintCustomerInfo();

