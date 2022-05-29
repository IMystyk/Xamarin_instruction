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
    class PeopleListViewAdapter : BaseAdapter <Person>
    {

        Context context;
        private List<Person> people;

        public PeopleListViewAdapter(Context context, List<Person> people)
        {
            this.context = context;
            this.people = people;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Person this[int position]
        {
            get { return people[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.people_listview_row, null, false);
            }

            TextView txt_name = row.FindViewById<TextView>(Resource.Id.txt_name);
            txt_name.Text = people[position].name;

            TextView txt_surname = row.FindViewById<TextView>(Resource.Id.txt_surname);
            txt_surname.Text = people[position].surname;

            TextView txt_age = row.FindViewById<TextView>(Resource.Id.txt_age);
            txt_age.Text = people[position].age.ToString();

            return row;
        }
        public override int Count
        {
            get
            {
                return people.Count;
            }
        }

    }
}