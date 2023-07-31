using System;
namespace DesignPattern
{
    //public class Parent
    //{
    //    private Child _child;

    //    public Parent()
    //    {
    //        _child = new Child();
    //    }

    //    public void Yah()
    //    {
    //        _child.Yah();
    //    }

    //    private class Child
    //    {
    //        public void Yah()
    //        {
    //            Console.WriteLine("Yah yah");
    //        }
    //    }
    //}


    public abstract class Child
    {
        public Child()
        {
            var type = typeof(Child);
            if (type.Namespace != "DesignPattern")
            {
                throw new Exception("Can not create instance from this name space");
            }
        }
    }

    public class Child1 : Child
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
    }

    public class Parent
    {
        public Parent()
        {
            var child1 = new Child1();
        }
    }
}

