using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public Header(string headerAsString)
        {
            string[] headerParts = headerAsString.Split(new string[] { ": " }, StringSplitOptions.None);
            this.Name = headerParts[0];
            this.Value = headerParts[1];
        }    
        
        //Cache-Control: no-cache       
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }

    }
}
