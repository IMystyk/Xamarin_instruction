using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instruction
{
    [Activity(Label = "PersonDetails")]
    public class PersonDetails : Activity
    {
        Person person;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.person_details_activity);

            person = JsonConvert.DeserializeObject<Person>(Intent.GetStringExtra("Person"));

            FindViewById<TextView>(Resource.Id.txt_name).Text = person.name;
            FindViewById<TextView>(Resource.Id.txt_surname).Text = person.surname;
            FindViewById<TextView>(Resource.Id.txt_age).Text = person.age.ToString();
            FindViewById<TextView>(Resource.Id.txt_gender).Text = person.gender;
        }


    }
}