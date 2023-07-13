// See https://aka.ms/new-console-template for more information
using Syntax.Practice.OOP.Constructor;

Console.WriteLine("Hello, World!");

// Private Constructor
// ProductOwner p = new ProductOwner();
Item a = new Item();
Item b = new Item();

List<int> items = new List<int> { 1, 2, 3 };
var res = items.GroupBy(x => x);
Console.WriteLine(res);