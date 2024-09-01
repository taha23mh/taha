using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Person
    {
        public string NationalCode { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public string Family { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, National Code: {NationalCode}, Phone: {PhoneNumber}, Gender: {(Gender == true ? "Male" : " Female")}";
        }
    }
}