using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sobey.DataStructure.HashTable.Model
{
    public class StudentInfo
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public StudentInfo()
        {
        }

        public StudentInfo(string number, string address)
        {
            Number = number;
            Address = address;
        }
    }
}
