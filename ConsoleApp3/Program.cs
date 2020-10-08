using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Print();
        }
    }

    public class Animal
    {
        public void MakeSound([CallerMemberName]string name = null)
        {
            string type = this.GetType().Name;
            Console.WriteLine(type);
            
            

        }
    }

    public class Dog : Animal
    {
        public void Print()
        {
            base.MakeSound();
        }
    }


}
