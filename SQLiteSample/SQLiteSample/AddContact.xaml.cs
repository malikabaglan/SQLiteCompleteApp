using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SQLiteSample
{
    public partial class AddContact : ContentPage
    {
        public AddContact()
        {
           // InitializeComponent();
            BindingContext = new AddContactViewModel(Navigation);
        }
    }
}