using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Practice.OOP.Constructor
{
    /*https://www.simplilearn.com/tutorials/c-sharp-tutorial/c-sharp-constructor
    Constructor is a special class method that is called very time when a new instance of class was created, it used to set value for property for data member of class
    We have five type of constructor: 
    - Default Constructor
    - Prameterized Constructor
    - Copy Constructor
    - Private Constructor
    - Static Constructor
    */
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Product()
        {
            // Default constructor is a constructor which do not have any parametered,
            // and it will be called when an instance of class was created, it set number to zero and string to null
            Console.WriteLine("Default Constructor");
            Console.WriteLine($@"Name: {Name} and Name is NULL {Name is null}");
            Console.WriteLine($@"Price: {Price} and Price is Zero {Price is 0}");
        }

        public Product(string name)
        {
            // Parameterized constructor is a constructor which at least one parameter, and it can set difference value for each instance of class
            Name = name;
            Console.WriteLine("Parameterlized Constructor");
        }

        public Product(Product copy)
        {
            // Copy Constructor is a constructor to set value for new instance from the existing one
            Name = copy.Name;
            Console.WriteLine("Copy Constructor");
        }
    }

    public class ProductOwner
    {
        public string Name { get; set; }
        private ProductOwner() 
        {
            // Private Constructor is a constructor that is created with private specifier, Other class can not inherited or create an instance of this class.
            // it used to initilize the class static field
            Console.WriteLine("Private Constructor");
        }
    }

    // Private Constructor => throw error
    //public class ProductManager: ProductOwner
    //{

    //}

    public class Item
    {
        static Item()
        {   
            // Static Constructor is a constructor will be called one time when the first instance of class was created
            Console.WriteLine("Static Constructor");
        }
    }
}
