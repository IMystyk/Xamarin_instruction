using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Instruction
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private List<Person> people;
        private ListView people_listview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            people_listview = FindViewById<ListView>(Resource.Id.list_people);

            people = new List<Person>();
            people.Add(new Person("John", "Smith", 24, "male"));
            people.Add(new Person("Will", "Krigg", 47, "male"));
            people.Add(new Person("Emily", "Sneeze", 56, "female"));


            PeopleListViewAdapter adapter = new PeopleListViewAdapter(this, people);
            people_listview.Adapter = adapter;

            FindViewById<TextView>(Resource.Id.txt_name_header).Click += (sender, e) =>
            {
                people = people.OrderBy(o => o.name).ToList();
                PeopleListViewAdapter adapter = new PeopleListViewAdapter(this, people);
                people_listview.Adapter = adapter;
            };
            FindViewById<TextView>(Resource.Id.txt_surname_header).Click += (sender, e) =>
            {
                people = people.OrderBy(o => o.surname).ToList();
                PeopleListViewAdapter adapter = new PeopleListViewAdapter(this, people);
                people_listview.Adapter = adapter;
            };
            FindViewById<TextView>(Resource.Id.txt_age_header).Click += (sender, e) =>
            {
                people = people.OrderBy(o => o.age).ToList();
                PeopleListViewAdapter adapter = new PeopleListViewAdapter(this, people);
                people_listview.Adapter = adapter;
            };

            people_listview.ItemLongClick += people_ItemLongClick;

        }

        void people_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(PersonDetails));

            Person person = people[e.Position];
            intent.PutExtra("Person", JsonConvert.SerializeObject(person));
            this.StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}