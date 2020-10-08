using System;

namespace c
{
    public class Dog
    {
        public Dog()
        {
        }

        public Dog(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }


        public string Name { get; set; }

        public int Age { get; set; }
    }
}
