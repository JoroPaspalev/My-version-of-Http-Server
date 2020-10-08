using System;

public interface IAnimal
{
    void MakeSound();
}

public  class Animal : IAnimal
{

    public virtual void MakeSound()
    {
        Console.WriteLine("Mrrrrrrrr");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bay bay");
    }
}

public class Cat : Animal
{

}

public class Test
{
    public static void Main()
    {

        Dog dog = new Dog();
        Animal animal = new Animal();
        object dog1 = dog;
        Animal animal1 = dog;

        Console.WriteLine(dog.GetType());
        Console.WriteLine(animal.GetType());
        Console.WriteLine(dog1.GetType());
        Console.WriteLine(dog1.GetType());








        //Animal animal = new Animal();
        //Dog dog = new Dog();
        //object o = dog;
        //Animal b = dog;

        //Console.WriteLine("mybase: Type is {0}", animal.GetType());
        //Console.WriteLine("myDerived: Type is {0}", dog.GetType());
        //Console.WriteLine("object o = Dog: Type is {0}", o.GetType());
        //Console.WriteLine("MyBaseClass b = Dog: Type is {0}", b.GetType());
    }
}
// The example displays the following output:
//    mybase: Type is MyBaseClass
//    myDerived: Type is MyDerivedClass
//    object o = myDerived: Type is MyDerivedClass
//    MyBaseClass b = myDerived: Type is MyDerivedClass