using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instruction
{
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }

        public Person(string name, string surname, int age, string gender)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
        }
    }
}