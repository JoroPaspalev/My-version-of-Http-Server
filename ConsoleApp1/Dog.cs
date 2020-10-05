using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Dog
    {
        private string dogNames;

        public Dog(string fullDogName)
        {
            this.dogNames = fullDogName;
        }

        public void ParseNames()
        {
            string[] names = dogNames.Split("  ");
            this.FirstName = names[0];
            this.LastName = names[1];
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }



    }
}
