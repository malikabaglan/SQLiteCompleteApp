using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SQLiteSample
{
    public partial class ContactList : ContentPage
    {
        public ContactList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new ContactListViewModel(Navigation);
        }
    }
}